export class StripeElementsInterop {
    constructor() {
        this.stripeElementsGroups = [];
        this.observers = new Map();
    }

    async create(groupId, configJson, dotNetCallback) {
        const config = JSON.parse(configJson);

        const stripe = window.Stripe(config.publishableKey);
        const elements = stripe.elements(config.stripeConfiguration);

        const group = {
            id: groupId,
            stripe,
            elements,
            components: {}
        };

        if (config.linkAuthenticationElementId) {
            const linkAuthTarget = document.getElementById(config.linkAuthenticationElementId);

            if (linkAuthTarget) {
                const options = {};
                if (config.customerEmail) {
                    options.defaultValues = { email: config.customerEmail };
                }

                group.components.linkAuth = elements.create("linkAuthentication", options);
                group.components.linkAuth.mount(linkAuthTarget);
            }
        }

        if (config.paymentElementId) {
            const paymentTarget = document.getElementById(config.paymentElementId);

            if (paymentTarget) {
                const billingDetails = {};
                if (config.customerEmail) billingDetails.email = config.customerEmail;
                if (config.customerName) billingDetails.name = config.customerName;

                const options = {};
                if (Object.keys(billingDetails).length > 0) {
                    options.defaultValues = { billingDetails };
                }

                group.components.payment = elements.create("payment", options);
                group.components.payment.mount(paymentTarget);
            }
        }

        if (config.addressElementId) {
            const addressTarget = document.getElementById(config.addressElementId);

            if (addressTarget) {
                const options = {
                    mode: config.addressMode || "billing" // fallback to billing if not specified
                };

                // Set defaultValues if provided
                if (config.addressDefaultValues && typeof config.addressDefaultValues === "object") {
                    options.defaultValues = config.addressDefaultValues;
                }

                // Set allowedCountries if provided
                if (Array.isArray(config.addressAllowedCountries) && config.addressAllowedCountries.length > 0) {
                    options.allowedCountries = config.addressAllowedCountries;
                }

                // Set blockPoBox if provided
                if (typeof config.addressBlockPoBox === "boolean") {
                    options.blockPoBox = config.addressBlockPoBox;
                }

                // Set autocomplete if addressAutocompleteApiKey is provided
                if (typeof config.addressAutocompleteApiKey === "string" && config.addressAutocompleteApiKey.length > 0) {
                    options.autocomplete = {
                        mode: "google_maps_api",
                        apiKey: config.addressAutocompleteApiKey
                    };
                }

                // Set phone field option if provided
                if (typeof config.addressFieldsPhone === "string" && config.addressFieldsPhone.length > 0) {
                    options.fields = {
                        phone: config.addressFieldsPhone
                    };
                }

                group.components.address = elements.create("address", options);
                group.components.address.mount(addressTarget);
            }
        }

        this.stripeElementsGroups.push(group);

        await dotNetCallback.invokeMethodAsync("OnInitializedJs");
    }

    async validatePayment(groupId, dotNetCallback) {
        const group = this._findGroup(groupId);

        if (!group) {
            console.error(`StripeElements group "${groupId}" not found for validation.`);
            return;
        }

        const result = await group.elements.submit();
        await dotNetCallback.invokeMethodAsync("OnValidatePaymentJs", result.error);
    }

    async submitPayment(groupId, paymentIntentSecret, returnUrl, dotNetCallback) {
        const group = this._findGroup(groupId);

        if (!group) {
            console.error(`StripeElements group "${groupId}" not found for submission.`);
            return;
        }

        if (!paymentIntentSecret || typeof paymentIntentSecret !== "string") {
            console.error("❌ Missing or invalid paymentIntentSecret (clientSecret) in submitPayment call");
            return;
        }

        const result = await group.stripe.confirmPayment({
            clientSecret: paymentIntentSecret,
            elements: group.elements,
            confirmParams: {
                return_url: returnUrl
            },
            redirect: "if_required"
        });

        await dotNetCallback.invokeMethodAsync("OnSubmitPaymentJs", result.error);
    }

    unmountGroup(groupId) {
        const group = this._findGroup(groupId);
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

        this.stripeElementsGroups = this.stripeElementsGroups.filter(g => g.id !== groupId);

        const observer = this.observers.get(groupId);
        if (observer) {
            observer.disconnect();
            this.observers.delete(groupId);
        }
    }

    createObserver(groupId, elementId) {
        const target = document.getElementById(elementId);

        if (!target) {
            console.warn(`Target element "${elementId}" not found for observer.`);
            return;
        }

        const observer = new MutationObserver((mutations) => {
            const targetRemoved = mutations.some(mutation =>
                Array.from(mutation.removedNodes).includes(target)
            );

            if (targetRemoved) {
                this.unmountGroup(groupId);

                const currentObserver = this.observers.get(groupId);
                if (currentObserver) {
                    currentObserver.disconnect();
                    this.observers.delete(groupId);
                }
            }
        });

        if (target?.parentNode) {
            observer.observe(target.parentNode, { childList: true });
            this.observers.set(groupId, observer);
        }
    }

    _findGroup(groupId) {
        return this.stripeElementsGroups.find(g => g.id === groupId);
    }
}

window.StripeElementsInterop = new StripeElementsInterop();
