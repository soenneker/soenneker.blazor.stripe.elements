﻿export class StripeElementsInterop {
    constructor() {
        this.stripeElementsGroups = [];
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
                const defaultValues = {};

                if (config.customerEmail)
                    defaultValues.email = config.customerEmail;

                group.components.linkAuth = elements.create("linkAuthentication", {
                    defaultValues
                });
                group.components.linkAuth.mount(linkAuthTarget);
            }
        }

        if (config.paymentElementId) {
            const paymentTarget = document.getElementById(config.paymentElementId);

            if (paymentTarget) {
                const defaultValues = {};

                if (config.customerEmail || config.customerName) {
                    defaultValues.billingDetails = {};

                    if (config.customerEmail)
                        defaultValues.billingDetails.email = config.customerEmail;

                    if (config.customerName)
                        defaultValues.billingDetails.name = config.customerName;
                }

                group.components.payment = elements.create("payment", {
                    defaultValues
                });
                group.components.payment.mount(paymentTarget);
            }
        }

        if (config.addressElementId) {
            const addressTarget = document.getElementById(config.addressElementId);

            if (addressTarget) {
                const defaultValues = {};
                if (config.customerName)
                    defaultValues.name = config.customerName;

                group.components.address = elements.create("address", {
                    mode: "billing",
                    defaultValues
                });
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
        await dotNetCallback.invokeMethodAsync('OnValidatePaymentJs', result.error);
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

        await dotNetCallback.invokeMethodAsync('OnSubmitPaymentJs', result.error);
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
    }

    createObserver(elementId) {
        const target = document.getElementById(elementId);

        this.observer = new MutationObserver((mutations) => {
            const targetRemoved = mutations.some(mutation =>
                Array.from(mutation.removedNodes).indexOf(target) !== -1
            );

            if (targetRemoved) {
                this.unmountGroup(elementId);

                this.observer && this.observer.disconnect();
                delete this.observer;
            }
        });

        if (target && target.parentNode) {
            this.observer.observe(target.parentNode, { childList: true });
        }
    }

    _findGroup(groupId) {
        return this.stripeElementsGroups.find(g => g.id === groupId);
    }
}

window.StripeElementsInterop = new StripeElementsInterop();
