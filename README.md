[![](https://img.shields.io/nuget/v/soenneker.blazor.stripe.elements.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.stripe.elements/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.stripe.elements/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.stripe.elements/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.stripe.elements.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.stripe.elements/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Blazor.Stripe.Elements

**A modular, strongly-typed Blazor library for Stripe Elements** — designed to provide first-class C# configuration and deep interop with Stripe.js. Built for modern Blazor projects using Stripe's Payment, Link Authentication, and Address Elements.

## ✨ Features

* 🔌 **Blazor-native components** for `<StripeElements>`, `<StripePaymentElement>`, `<StripeLinkAuthenticationElement>`, and `<StripeAddressElement>`
* 🧠 **Fully configurable via C#** — with strong typing for all supported options, including appearance, locale, currency, developer tools, and more
* 🎨 **Appearance API support** with extensible theming and rule control
* 📦 **Supports SetupIntents**, on-submit hooks, and validation workflows
* 🧪 Compatible with Stripe test environments and developer tooling
* 💬 Built-in callback support for validation and error responses
* 🔄 Seamless async interop with Stripe.js lifecycle

## 📦 Installation

```bash
dotnet add package Soenneker.Blazor.Stripe.Elements
```

---

## 🛠️ Usage

### 1. Register Stripe in your Blazor project

```csharp
builder.Services.AddStripeElementsInteropAsScoped();
```

### 2. Add the components to your Razor page

```razor
<StripeElements @ref="_stripeElements"
                StripeElementsConfiguration="_config"
                OnSubmitPayment="HandleStripeSubmit"
                OnValidatePayment="HandleStripeValidate">

    <StripeAddressElement />
    <StripeLinkAuthenticationElement />
    <StripePaymentElement />

    <Button Clicked="Submit">Submit</Button>
</StripeElements>
```

### 3. Configure Stripe using C\#

```csharp
_config = new StripeElementsConfiguration
{
    PublishableKey = "pk_test_...",
    ElementsOptions = new StripeElementsOptions
    {
        Locale = "auto",
        Currency = CurrencyCode.Usd,
        Mode = StripeElementsMode.Setup,
        Appearance = new StripeAppearance
        {
            Theme = StripeElementsTheme.Flat,
            Variables = new StripeAppearanceVariablesExtended
            {
                ColorPrimary = "#0570de",
                BorderRadius = "4px"
            }
        }
    },
    AddressOptions = new StripeAddressOptions
    {
        Mode = StripeAddressMode.Billing,
        AllowedCountries = ["US", "CA"],
        Fields = new StripeAddressFields
        {
            Phone = StripeAddressFieldsPhoneOption.Auto,
            PostalCode = StripeAddressFieldsPostalCodeOption.Never
        }
    }
};
```

---

## ✅ Components

| Component                         | Purpose                                    |
| --------------------------------- | ------------------------------------------ |
| `StripeElements`                  | Wrapper and manager for all child elements |
| `StripePaymentElement`            | Handles card and express payments          |
| `StripeLinkAuthenticationElement` | Collects email and links with Stripe Link  |
| `StripeAddressElement`            | Collects billing or shipping address       |
| `StripeElementsConfiguration`     | Full C# model to control everything        |

---

## 🔄 Event Callbacks

| Event               | Description                                                                |
| ------------------- | -------------------------------------------------------------------------- |
| `OnValidatePayment` | Triggered before attempting to submit a payment (for preflight validation) |
| `OnSubmitPayment`   | Triggered after attempting to submit the payment intent or method          |

```csharp
public async Task HandleStripeValidate(StripeErrorDto? error) { ... }
public async Task HandleStripeSubmit(StripeErrorDto? error) { ... }
```

---


## 🔗 Official Stripe Docs (Updated)

* 🌐 [Stripe Elements Overview](https://docs.stripe.com/elements)
* ⚙️ [Elements JavaScript API Reference](https://docs.stripe.com/js/element)
* 💳 [Payment Element](https://docs.stripe.com/js/element/payment_element)
* 📬 [Address Element](https://docs.stripe.com/js/element/address_element)
* 🔐 [Link Authentication Element](https://docs.stripe.com/js/element/link_authentication_element)
* 🎨 [Appearance API (Theme & Styling)](https://docs.stripe.com/elements/appearance-api)