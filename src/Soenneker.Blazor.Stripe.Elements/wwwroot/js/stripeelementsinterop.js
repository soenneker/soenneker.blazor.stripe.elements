const stripeElementsGroups = [];
const stripeObservers = new Map();
const stripeCache = new Map();

function getStripe(publishableKey) {
        if (!stripeCache.has(publishableKey)) {
            stripeCache.set(publishableKey, window.Stripe(publishableKey));
        }
        return stripeCache.get(publishableKey);
}
export async function create(groupId, configJson, dotNetCallback) {
        if (findStripeGroup(groupId)) {
            console.warn(`Group "${groupId}" already exists. Skipping creation.`);
            return;
        }

        const config = JSON.parse(configJson);

        const stripe = getStripe(config.publishableKey);
        const elements = stripe.elements(config.elementsOptions ?? {});

        const group = {
            id: groupId,
            stripe,
            elements,
            components: {}
        };

        try {
            if (config.linkAuthenticationElementId && config.linkAuthenticationOptions) {
                const target = document.getElementById(config.linkAuthenticationElementId);
                if (target) {
                    const element = elements.create("linkAuthentication", config.linkAuthenticationOptions);

                    element.on("ready", () => {
                        dotNetCallback.invokeMethodAsync("OnLinkAuthenticationElementReadyJs");
                    });

                    element.mount(target);
                    group.components.linkAuth = element;
                } else {
                    console.error(`Could not find Stripe linkAuthentication element with id '${config.linkAuthenticationElementId}'`);
                }
            }

            if (config.paymentElementId && config.paymentOptions) {
                const target = document.getElementById(config.paymentElementId);
                if (target) {
                    const element = elements.create("payment", config.paymentOptions);

                    element.on("ready", () => {
                        dotNetCallback.invokeMethodAsync("OnPaymentElementReadyJs");
                    });

                    element.mount(target);
                    group.components.payment = element;
                } else {
                    console.error(`Could not find Stripe payment element with id '${config.paymentElementId}'`);
                }
            }

            if (config.addressElementId && config.addressOptions) {
                const target = document.getElementById(config.addressElementId);
                if (target) {
                    const element = elements.create("address", config.addressOptions);

                    element.on("ready", () => {
                        dotNetCallback.invokeMethodAsync("OnAddressElementReadyJs");
                    });

                    element.mount(target);
                    group.components.address = element;
                } else {
                    console.error(`Could not find Stripe address element with id '${config.addressElementId}'`);
                }
            }

            stripeElementsGroups.push(group);

            try {
                await dotNetCallback.invokeMethodAsync("OnInitializedJs");
            } catch (e) {
                console.error("Failed to invoke .NET OnInitializedJs:", e);
            }

        } catch (e) {
            console.error("Error during element creation, rolling back group:", e);
            unmountGroup(groupId);
        }
    };
export async function confirmPayment(groupId, clientSecret, returnUrl) {
        const group = findStripeGroup(groupId);
        if (!group) {
            console.error(`StripeElements group "${groupId}" not found for confirmPayment.`);
            return;
        }

        return await group.stripe.confirmPayment({
            elements: group.elements,
            clientSecret,
            confirmParams: {
                return_url: returnUrl
            },
            redirect: "if_required"
        });
    };
export async function submit(groupId) {
        const group = findStripeGroup(groupId);
        if (!group) {
            console.error(`StripeElements group "${groupId}" not found for submit.`);
            return { error: { message: "Group not found" } };
        }

        try {
            const result = await group.elements.submit();
            return result;
        } catch (e) {
            console.warn(`Stripe elements.submit() failed: ${e?.message}`);
            return { error: { message: e?.message ?? "Unknown error during submit" } };
        }
    };
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
    };
export async function confirmSetup(groupId, clientSecret, returnUrl) {
        const group = findStripeGroup(groupId);
        if (!group) {
            console.error(`StripeElements group "${groupId}" not found for confirmSetup.`);
            return;
        }

        return await group.stripe.confirmSetup({
            clientSecret,
            elements: group.elements,
            confirmParams: {
                return_url: returnUrl
            },
            redirect: "if_required"
        });
    };
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
    };
function disconnectStripeObserver(groupId) {
        const observer = stripeObservers.get(groupId);
        if (observer) {
            observer.disconnect();
            stripeObservers.delete(groupId);
        }
    };
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
            observer.observe(target.parentNode, { childList: true });
            stripeObservers.set(groupId, observer);
        }
    };
function findStripeGroup(groupId) {
        return stripeElementsGroups.find(g => g.id === groupId);
    };
