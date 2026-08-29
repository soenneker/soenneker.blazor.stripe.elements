[![](https://img.shields.io/nuget/v/soenneker.blazor.stripe.elements.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.stripe.elements/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.stripe.elements/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.stripe.elements/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.stripe.elements.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.stripe.elements/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.stripe.elements/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.stripe.elements/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Blazor.Stripe.Elements

Strongly typed Blazor components and interop for Stripe Payment, Card, Address, Link Authentication, and Checkout Sessions Elements.

<img src="https://github.com/user-attachments/assets/a2f8777a-02e0-40de-afd6-fe4d1211427b" width="80%" alt="Stripe Elements example" />

## Installation

```bash
dotnet add package Soenneker.Blazor.Stripe.Elements
```

Register the interop service in `Program.cs`:

```csharp
using Soenneker.Blazor.Stripe.Elements.Registrars;

builder.Services.AddStripeElementsInteropAsScoped();
```

Add the component namespace to `_Imports.razor`:

```razor
@using Soenneker.Blazor.Stripe.Elements
```

## Payment Element example

Create the PaymentIntent on your server. Return its client secret only to the customer who is allowed to complete that payment, then configure and render Elements:

```razor
@inject HttpClient Http
@inject NavigationManager Navigation

@using Soenneker.Blazor.Stripe.Elements.Configuration
@using Soenneker.Blazor.Stripe.Elements.Configuration.Elements
@using Soenneker.Blazor.Stripe.Elements.Configuration.Payment
@using Soenneker.Blazor.Stripe.Elements.Dtos

@if (_configuration is null)
{
    <p>Preparing checkout…</p>
}
else
{
    <StripeElements @ref="_elements"
                    Configuration="_configuration"
                    OnPaymentElementReady="HandlePaymentElementReady">
        <StripePaymentElement />
    </StripeElements>

    <button type="button" disabled="@(!_ready || _submitting)" @onclick="PayAsync">
        Pay
    </button>

    @if (_error is not null)
    {
        <p role="alert">@_error</p>
    }
}

@code {
    private StripeElements? _elements;
    private StripeElementsConfiguration? _configuration;
    private bool _ready;
    private bool _submitting;
    private string? _error;

    protected override async Task OnInitializedAsync()
    {
        // This endpoint creates the PaymentIntent using server-controlled amount,
        // currency, customer, and order data, then returns its client secret.
        string clientSecret = await Http.GetStringAsync("api/payments/create-intent");

        _configuration = new StripeElementsConfiguration
        {
            PublishableKey = "pk_test_replace_me",
            ElementsOptions = new StripeElementsOptions
            {
                ClientSecret = clientSecret,
                Locale = "auto"
            },
            PaymentOptions = new StripePaymentElementOptions()
        };
    }

    private void HandlePaymentElementReady() => _ready = true;

    private async Task PayAsync()
    {
        _submitting = true;
        _error = null;

        try
        {
            StripeSubmitResult? validation = await _elements!.Submit();
            if (validation?.Error is not null)
            {
                _error = validation.Error.Message;
                return;
            }

            string returnUrl = Navigation.ToAbsoluteUri("/payments/complete").ToString();
            StripeConfirmResult? result = await _elements.ConfirmPayment(returnUrl);
            _error = result?.Error?.Message;
        }
        finally
        {
            _submitting = false;
        }
    }
}
```

`ConfirmPayment()` uses the client secret in `ElementsOptions` unless one is passed explicitly. It sets Stripe's redirect behavior to `if_required`, so redirect-based payment methods can still leave the page and later return to `returnUrl`.

## Configuration controls what mounts

Child markup provides the target element; the matching options property enables creation:

| Child component | Required configuration |
| --- | --- |
| `StripePaymentElement` | `PaymentOptions` |
| `StripeCardElement` | `CardOptions` |
| `StripeAddressElement` | `AddressOptions` |
| `StripeLinkAuthenticationElement` | `LinkAuthenticationOptions` |
| `StripeContactDetailsElement` | `CheckoutSessionOptions` and `ContactDetailsOptions` |

Keep all element components inside the same `StripeElements` parent. Rendering a child without its matching options leaves an empty target; supplying options without rendering the target prevents that element from mounting.

The single-line Card Element uses `ConfirmCardPayment()` or `ConfirmCardSetup()`. The Payment Element uses `Submit()` followed by `ConfirmPayment()` or `ConfirmSetup()`. Checkout Sessions mode is selected by setting `CheckoutSessionOptions` and is confirmed with `ConfirmCheckout()`.

## Lifecycle

- Automatic initialization occurs after the first interactive render. Set `ManuallyInitialize="true"` and call `Initialize()` after `OnElementRendered` when configuration must be supplied later.
- `OnInitialize` reports that the Stripe group was created. Element-specific ready callbacks report when their corresponding iframe is interactive.
- Configuration is consumed when the group is created; mutating the object afterward does not rebuild mounted Elements.
- `Update()` asks mounted elements to recalculate after a hidden container, tab, or modal becomes visible.
- `Unmount()` destroys the mounted group. The component can then be initialized again with new configuration.

## Payment and secret handling

- A publishable key (`pk_…`) belongs in browser configuration. Secret and restricted API keys (`sk_…` and `rk_…`) must remain on the server and are rejected by the component.
- PaymentIntent, SetupIntent, CustomerSession, and Checkout Session client secrets are browser-facing capabilities, but they are still sensitive. Serve them over TLS only to the intended customer; never log them, put them in URLs, or persist them in analytics.
- Calculate amounts, currencies, discounts, customer ownership, and order contents on the server. Never accept those values from the browser without authoritative validation.
- Treat the client confirmation result as user-interface feedback, not final fulfillment authority. Verify payment state on the server and process signed Stripe webhooks idempotently before delivering goods or services.
- Use a fixed, application-owned HTTPS return URL. Do not pass an unvalidated user-supplied return URL into a confirmation method.
- Stripe-hosted iframes keep raw payment details out of your Blazor component, but they do not remove your compliance obligations. Review Stripe's integration and PCI guidance for your deployment.

The package loads Stripe.js directly from `https://js.stripe.com/dahlia/stripe.js`. Your Content Security Policy and network controls must permit the Stripe script, frames, and connections required by the payment methods you enable.

## Stripe documentation

- [Stripe Elements](https://docs.stripe.com/elements)
- [Payment Element](https://docs.stripe.com/payments/payment-element)
- [PaymentIntents and client-secret handling](https://docs.stripe.com/payments/payment-intents)
- [Stripe.js API](https://docs.stripe.com/js)
- [API key security](https://docs.stripe.com/keys-best-practices)
