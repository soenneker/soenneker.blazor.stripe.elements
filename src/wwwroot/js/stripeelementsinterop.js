export class StripeElementsInterop {
    constructor() {
        this.stripeElementsGroups = [];
        this.observers = new Map();
    }

    async create(groupId, configJson, dotNetCallback) {
        const config = JSON.parse(configJson);

        const stripe = window.Stripe(config.publishableKey);
        const elements = stripe.elements(config.elementsOptions ?? {});

        const group = {
            id: groupId,
            stripe,
            elements,
            components: {}
        };

        // LINK AUTHENTICATION ELEMENT
        if (config.linkAuthenticationElementId && config.linkAuthenticationOptions) {
            const target = document.getElementById(config.linkAuthenticationElementId);
            if (target) {
                const element = elements.create("linkAuthentication", config.linkAuthenticationOptions);
                element.mount(target);
                group.components.linkAuth = element;
            }
        }

        // PAYMENT ELEMENT
        if (config.paymentElementId && config.paymentOptions) {
            const target = document.getElementById(config.paymentElementId);
            if (target) {
                const element = elements.create("payment", config.paymentOptions);
                element.mount(target);
                group.components.payment = element;
            }
        }

        // ADDRESS ELEMENT
        if (config.addressElementId && config.addressOptions) {
            const target = document.getElementById(config.addressElementId);
            if (target) {
                const element = elements.create("address", config.addressOptions);
                element.mount(target);
                group.components.address = element;
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
