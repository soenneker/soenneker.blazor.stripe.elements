const stripeElementsGroups = [];
const stripeObservers = new Map();
const stripeCache = new Map();

function getStripe(publishableKey, initializationOptions) {
    const cacheKey = JSON.stringify({publishableKey, initializationOptions: initializationOptions ?? null});

    if (!stripeCache.has(cacheKey)) {
        stripeCache.set(cacheKey, window.Stripe(publishableKey, initializationOptions ?? undefined));
    }

    return stripeCache.get(cacheKey);
}

export async function create(groupId, configJson, dotNetCallback) {
    if (findStripeGroup(groupId)) {
        console.warn(`Group "${groupId}" already exists. Skipping creation.`);
        return;
    }

    const config = JSON.parse(configJson);
    const stripe = getStripe(config.publishableKey, config.initializationOptions);
    const checkoutMode = !!config.checkoutSessionOptions;

    let checkout = null;
    let actions = null;
    let session = null;
    let elements = null;

    const group = {
        id: groupId,
        stripe,
        checkout,
        actions,
        session,
        elements,
        components: {}
    };

    try {
        if (checkoutMode) {
            const checkoutOptions = buildCheckoutOptions(config);
            const checkoutFactory = stripe.initCheckoutElementsSdk ?? stripe.initCheckout;

            if (typeof checkoutFactory !== "function") {
                throw new Error("Stripe Checkout Sessions Elements SDK is not available in this Stripe.js version.");
            }

            checkout = await Promise.resolve(checkoutFactory.call(stripe, checkoutOptions));
            const loadResult = await checkout.loadActions();

            if (!loadResult || loadResult.type !== "success") {
                const message = loadResult?.error?.message ?? "Unable to initialize Stripe Checkout actions.";
                throw new Error(message);
            }

            actions = loadResult.actions;
            session = typeof actions.getSession === "function" ? actions.getSession() : null;
            group.checkout = checkout;
            group.actions = actions;
            group.session = session;
        } else {
            elements = stripe.elements(config.elementsOptions ?? {});
            group.elements = elements;
        }

        mountLinkAuthenticationElement(group, config, dotNetCallback);
        mountContactDetailsElement(group, config, dotNetCallback);
        mountPaymentElement(group, config, dotNetCallback);
        mountCardElement(group, config, dotNetCallback);
        mountAddressElement(group, config, dotNetCallback);

        stripeElementsGroups.push(group);

        try {
            await dotNetCallback.invokeMethodAsync("OnInitializedJs");
        } catch (e) {
            console.error("Failed to invoke .NET OnInitializedJs:", e);
        }
    } catch (e) {
        console.error("Error during element creation, rolling back group:", e);
        unmountGroup(groupId);
        throw e;
    }
}

export async function confirmPayment(groupId, clientSecret, returnUrl) {
    const group = findStripeGroup(groupId);
    if (!group) {
        console.error(`StripeElements group "${groupId}" not found for confirmPayment.`);
        return;
    }

    if (isCheckoutGroup(group)) {
        return await confirmCheckout(groupId, returnUrl, null);
    }

    return await group.stripe.confirmPayment({
        elements: group.elements,
        clientSecret,
        confirmParams: {
            return_url: returnUrl
        },
        redirect: "if_required"
    });
}

export async function submit(groupId) {
    const group = findStripeGroup(groupId);
    if (!group) {
        console.error(`StripeElements group "${groupId}" not found for submit.`);
        return {error: {message: "Group not found"}};
    }

    try {
        if (isCheckoutGroup(group)) {
            const actions = await getCheckoutActions(group);

            if (typeof actions.validateElements !== "function") {
                return {};
            }

            return await actions.validateElements();
        }

        return await group.elements.submit();
    } catch (e) {
        console.warn(`Stripe elements submit failed: ${e?.message}`);
        return {error: {message: e?.message ?? "Unknown error during submit"}};
    }
}

export function update(groupId) {
    const group = findStripeGroup(groupId);
    if (!group) {
        console.error(`StripeElements group "${groupId}" not found for update.`);
        return;
    }

    for (const [key, element] of Object.entries(group.components)) {
        if (typeof element.update === "function") {
            try {
                element.update({});
                console.debug(`Stripe element "${key}" updated.`);
            } catch (e) {
                console.warn(`Failed to update element "${key}":`, e);
            }
        }
    }
}

export async function confirmSetup(groupId, clientSecret, returnUrl) {
    const group = findStripeGroup(groupId);
    if (!group) {
        console.error(`StripeElements group "${groupId}" not found for confirmSetup.`);
        return;
    }

    if (isCheckoutGroup(group)) {
        return await confirmCheckout(groupId, returnUrl, null);
    }

    return await group.stripe.confirmSetup({
        clientSecret,
        elements: group.elements,
        confirmParams: {
            return_url: returnUrl
        },
        redirect: "if_required"
    });
}

export async function confirmCardPayment(groupId, clientSecret, billingDetailsJson) {
    const group = requireCardGroup(groupId, "confirmCardPayment");
    if (!group) return {error: {message: "Mounted Card Element not found"}};

    return await group.stripe.confirmCardPayment(clientSecret, {
        payment_method: buildCardPaymentMethod(group, billingDetailsJson)
    });
}

export async function confirmCardSetup(groupId, clientSecret, billingDetailsJson) {
    const group = requireCardGroup(groupId, "confirmCardSetup");
    if (!group) return {error: {message: "Mounted Card Element not found"}};

    return await group.stripe.confirmCardSetup(clientSecret, {
        payment_method: buildCardPaymentMethod(group, billingDetailsJson)
    });
}

export async function confirmCheckout(groupId, returnUrl, optionsJson) {
    const group = findStripeGroup(groupId);
    if (!group) {
        console.error(`StripeElements group "${groupId}" not found for confirmCheckout.`);
        return;
    }

    if (!isCheckoutGroup(group)) {
        console.error(`StripeElements group "${groupId}" was not initialized with CheckoutSessionOptions.`);
        return {error: {message: "CheckoutSessionOptions must be set to confirm a Checkout Session."}};
    }

    const actions = await getCheckoutActions(group);
    const options = parseOptions(optionsJson);

    if (returnUrl && !options.returnUrl) {
        options.returnUrl = returnUrl;
    }

    if (!options.redirect) {
        options.redirect = "if_required";
    }

    if (typeof actions.getSession === "function") {
        group.session = actions.getSession();
    }

    return Object.keys(options).length ? await actions.confirm(options) : await actions.confirm();
}

export function unmountGroup(groupId) {
    const group = findStripeGroup(groupId);
    if (!group) return;

    Object.values(group.components).forEach(component => {
        try {
            component.unmount();
            if (typeof component.destroy === "function") {
                component.destroy();
            }
        } catch (e) {
            console.warn(`Failed to unmount or destroy component: ${e}`);
        }
    });

    const groupIndex = stripeElementsGroups.findIndex(g => g.id === groupId);
    if (groupIndex > -1) {
        stripeElementsGroups.splice(groupIndex, 1);
    }

    disconnectStripeObserver(groupId);
}

export function createObserver(groupId) {
    const target = document.getElementById(groupId);
    if (!target) {
        console.warn(`Target element "${groupId}" not found for observer.`);
        return;
    }

    const observer = new MutationObserver((mutations) => {
        const targetRemoved = mutations.some(mutation =>
            Array.from(mutation.removedNodes).includes(target)
        );

        if (targetRemoved) {
            unmountGroup(groupId);
        }
    });

    if (target?.parentNode) {
        observer.observe(target.parentNode, {childList: true});
        stripeObservers.set(groupId, observer);
    }
}

function mountLinkAuthenticationElement(group, config, dotNetCallback) {
    if (!config.linkAuthenticationElementId || !config.linkAuthenticationOptions || isCheckoutGroup(group)) {
        return;
    }

    mountElement({
        targetId: config.linkAuthenticationElementId,
        componentName: "linkAuth",
        factory: () => group.elements.create("linkAuthentication", config.linkAuthenticationOptions),
        readyCallback: () => dotNetCallback.invokeMethodAsync("OnLinkAuthenticationElementReadyJs"),
        missingMessage: "Stripe linkAuthentication"
    }, group);
}

function mountContactDetailsElement(group, config, dotNetCallback) {
    if (!isCheckoutGroup(group)) {
        return;
    }

    const useContactDetailsTarget = config.contactDetailsElementId && config.contactDetailsOptions;
    const useLinkAuthenticationFallback = !useContactDetailsTarget && config.linkAuthenticationElementId && config.linkAuthenticationOptions;
    const targetId = useContactDetailsTarget ? config.contactDetailsElementId : config.linkAuthenticationElementId;

    if (!targetId || typeof group.checkout.createContactDetailsElement !== "function") {
        return;
    }

    if (!useContactDetailsTarget && !useLinkAuthenticationFallback) {
        return;
    }

    mountElement({
        targetId,
        componentName: "contactDetails",
        factory: () => group.checkout.createContactDetailsElement(),
        readyCallback: () => {
            if (useContactDetailsTarget) {
                return dotNetCallback.invokeMethodAsync("OnContactDetailsElementReadyJs");
            }

            return dotNetCallback.invokeMethodAsync("OnLinkAuthenticationElementReadyJs");
        },
        missingMessage: "Stripe contactDetails"
    }, group);
}

function mountPaymentElement(group, config, dotNetCallback) {
    if (!config.paymentElementId || !config.paymentOptions) {
        return;
    }

    mountElement({
        targetId: config.paymentElementId,
        componentName: "payment",
        factory: () => isCheckoutGroup(group)
            ? group.checkout.createPaymentElement(buildCheckoutPaymentOptions(config.paymentOptions))
            : group.elements.create("payment", config.paymentOptions),
        readyCallback: () => dotNetCallback.invokeMethodAsync("OnPaymentElementReadyJs"),
        missingMessage: "Stripe payment"
    }, group);
}

function mountCardElement(group, config, dotNetCallback) {
    if (!config.cardElementId || !config.cardOptions) {
        return;
    }

    if (isCheckoutGroup(group)) {
        console.warn("The Card Element is not supported by the Checkout Sessions Elements SDK.");
        return;
    }

    mountElement({
        targetId: config.cardElementId,
        componentName: "card",
        factory: () => group.elements.create("card", config.cardOptions),
        readyCallback: () => dotNetCallback.invokeMethodAsync("OnCardElementReadyJs"),
        changeCallback: event => dotNetCallback.invokeMethodAsync("OnCardElementChangeJs", sanitizeCardChangeEvent(event)),
        missingMessage: "Stripe card"
    }, group);
}

function buildCheckoutPaymentOptions(paymentOptions) {
    if (!paymentOptions) {
        return undefined;
    }

    return removeUndefinedProperties({
        fields: paymentOptions.fields,
        layout: paymentOptions.layout,
        paymentMethodOrder: paymentOptions.paymentMethodOrder,
        readOnly: paymentOptions.readOnly,
        terms: paymentOptions.terms,
        applePay: paymentOptions.applePay,
        wallets: paymentOptions.wallets
    });
}

function mountAddressElement(group, config, dotNetCallback) {
    if (!config.addressElementId || !config.addressOptions) {
        return;
    }

    const checkoutAddressFactory = isCheckoutGroup(group)
        ? getCheckoutAddressFactory(group.checkout, config.addressOptions)
        : null;

    if (isCheckoutGroup(group) && !checkoutAddressFactory) {
        console.warn("Stripe Checkout Sessions mode does not expose the requested Address Element in this Stripe.js version.");
        return;
    }

    mountElement({
        targetId: config.addressElementId,
        componentName: "address",
        factory: () => isCheckoutGroup(group)
            ? checkoutAddressFactory(buildCheckoutAddressOptions(config.addressOptions))
            : group.elements.create("address", config.addressOptions),
        readyCallback: () => dotNetCallback.invokeMethodAsync("OnAddressElementReadyJs"),
        missingMessage: "Stripe address"
    }, group);
}

function getCheckoutAddressFactory(checkout, addressOptions) {
    if (addressOptions?.mode === "shipping") {
        return typeof checkout.createShippingAddressElement === "function"
            ? checkout.createShippingAddressElement.bind(checkout)
            : null;
    }

    return typeof checkout.createBillingAddressElement === "function"
        ? checkout.createBillingAddressElement.bind(checkout)
        : null;
}

function buildCheckoutAddressOptions(addressOptions) {
    if (!addressOptions) {
        return undefined;
    }

    return removeUndefinedProperties({
        contacts: addressOptions.contacts ?? buildCheckoutAddressContacts(addressOptions.defaultValues),
        display: addressOptions.display,
        autocomplete: addressOptions.autocomplete
    });
}

function buildCheckoutAddressContacts(defaultValues) {
    if (!defaultValues) {
        return undefined;
    }

    const name = defaultValues.name ?? [defaultValues.firstName, defaultValues.lastName].filter(Boolean).join(" ");
    const contact = removeUndefinedProperties({
        name: name || undefined,
        phone: defaultValues.phone,
        address: defaultValues.address
    });

    return Object.keys(contact).length ? [contact] : undefined;
}

function mountElement(options, group) {
    const target = document.getElementById(options.targetId);
    if (!target) {
        console.error(`Could not find ${options.missingMessage} element with id '${options.targetId}'`);
        return;
    }

    const element = options.factory();

    element.on("ready", options.readyCallback);
    if (options.changeCallback) {
        element.on("change", options.changeCallback);
    }
    element.mount(target);
    group.components[options.componentName] = element;
}

function sanitizeCardChangeEvent(event) {
    return {
        complete: !!event.complete,
        empty: !!event.empty,
        brand: event.brand,
        error: event.error
    };
}

function requireCardGroup(groupId, operation) {
    const group = findStripeGroup(groupId);
    if (!group) {
        console.error(`StripeElements group "${groupId}" not found for ${operation}.`);
        return null;
    }

    if (!group.components.card) {
        console.error(`StripeElements group "${groupId}" does not contain a mounted Card Element.`);
        return null;
    }

    return group;
}

function buildCardPaymentMethod(group, billingDetailsJson) {
    const paymentMethod = {card: group.components.card};
    const billingDetails = parseOptions(billingDetailsJson);

    if (Object.keys(billingDetails).length) {
        paymentMethod.billing_details = billingDetails;
    }

    return paymentMethod;
}

async function getCheckoutActions(group) {
    if (group.actions) {
        return group.actions;
    }

    const loadResult = await group.checkout.loadActions();

    if (!loadResult || loadResult.type !== "success") {
        const message = loadResult?.error?.message ?? "Unable to load Stripe Checkout actions.";
        throw new Error(message);
    }

    group.actions = loadResult.actions;
    return group.actions;
}

function buildCheckoutOptions(config) {
    const checkoutOptions = {
        ...(config.checkoutSessionOptions ?? {})
    };

    checkoutOptions.clientSecret ??= config.elementsOptions?.clientSecret;

    if (!checkoutOptions.clientSecret) {
        throw new Error("Checkout Session client secret is missing.");
    }

    checkoutOptions.elementsOptions = buildCheckoutElementsOptions(checkoutOptions.elementsOptions ?? config.elementsOptions);
    checkoutOptions.adaptivePricing = buildCheckoutAdaptivePricingOptions(checkoutOptions.adaptivePricing);

    return checkoutOptions;
}

function buildCheckoutAdaptivePricingOptions(adaptivePricing) {
    if (adaptivePricing === undefined || adaptivePricing === null || typeof adaptivePricing === "object") {
        return adaptivePricing;
    }

    return {allowed: !!adaptivePricing};
}

function buildCheckoutElementsOptions(elementsOptions) {
    if (!elementsOptions) {
        return undefined;
    }

    return removeUndefinedProperties({
        fonts: elementsOptions.fonts,
        appearance: elementsOptions.appearance,
        loader: elementsOptions.loader
    });
}

function parseOptions(optionsJson) {
    if (!optionsJson) {
        return {};
    }

    return JSON.parse(optionsJson);
}

function removeUndefinedProperties(value) {
    return Object.fromEntries(Object.entries(value).filter(([, entry]) => entry !== undefined && entry !== null));
}

function disconnectStripeObserver(groupId) {
    const observer = stripeObservers.get(groupId);
    if (observer) {
        observer.disconnect();
        stripeObservers.delete(groupId);
    }
}

function findStripeGroup(groupId) {
    return stripeElementsGroups.find(g => g.id === groupId);
}

function isCheckoutGroup(group) {
    return !!group.checkout;
}
