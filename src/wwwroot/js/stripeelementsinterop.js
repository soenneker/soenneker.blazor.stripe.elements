export class StripeElementsInterop {
    constructor() {
        this.stripe = null;
        this.elements = null;
        this.paymentElement = null;
        this.addressElement = null;
        this.linkAuthElement = null;
        this.stripeOptions = null;
    }

    create(element, elementId, config, dotNetCallback) {
        const parsedConfig = JSON.parse(config);

        this.stripe = window.Stripe(parsedConfig.publishableKey);
        this.stripeOptions = parsedConfig.stripeConfiguration;

        this.elements = this.stripe.elements(this.stripeOptions);

        this.linkAuthElement = this.elements.create('linkAuthentication', {
            defaultValues: { email: parsedConfig.customerEmail }
        });

        this.paymentElement = this.elements.create('payment', {
            mode: "payment",
            defaultValues: {
                email: parsedConfig.customerEmail,
                name: parsedConfig.customerName
            }
        });

        this.addressElement = this.elements.create('address', {
            mode: "billing",
            defaultValues: {
                name: parsedConfig.customerName
            }
        });

        const linkAuthTarget = parsedConfig.linkAuthElement || "stripe-link-authentication-element";
        const paymentTarget = parsedConfig.paymentElement || "stripe-payment-element";
        const addressTarget = parsedConfig.addressElement || "stripe-address-element";

        this.linkAuthElement.mount(`#${linkAuthTarget}`);
        this.paymentElement.mount(`#${paymentTarget}`);
        this.addressElement.mount(`#${addressTarget}`);

        dotNetCallback.invokeMethodAsync("OnInitializedJs")
    }

    validatePayment(dotNetHelper) {
        this.elements.submit().then(result => {
            dotNetHelper.invokeMethodAsync('OnValidatePaymentJs', result.error);
        });
    }

    submitPayment(paymentIntentSecret, returnUrl, dotNetHelper) {
        this.stripe.confirmPayment({
            clientSecret: paymentIntentSecret,
            elements: this.elements,
            confirmParams: {
                return_url: returnUrl
            },
            redirect: "if_required"
        }).then(result => {
            dotNetHelper.invokeMethodAsync('OnSubmitPaymentJs', result.error);
        });
    }

    createObserver(elementId) {
        const target = document.getElementById(elementId);

        this.observer = new MutationObserver((mutations) => {
            const targetRemoved = mutations.some(mutation => Array.from(mutation.removedNodes).indexOf(target) !== -1);

            if (targetRemoved) {
                this.observer && this.observer.disconnect();
                delete this.observer;
            }
        });

        this.observer.observe(target.parentNode, { childList: true });
    }
}

window.StripeElementsInterop = new StripeElementsInterop();