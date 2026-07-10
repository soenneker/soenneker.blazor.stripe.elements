using Soenneker.Blazor.Stripe.Elements.Configuration.LinkAuthentication;
using Soenneker.Blazor.Stripe.Elements.Configuration.Payment;
using Soenneker.Blazor.Stripe.Elements.Configuration.Address;
using System.Text.Json.Serialization;
using Soenneker.Blazor.Stripe.Elements.Configuration.Checkout;
using Soenneker.Blazor.Stripe.Elements.Configuration.ContactDetails;
using Soenneker.Blazor.Stripe.Elements.Configuration.Elements;
using Soenneker.Blazor.Stripe.Elements.Configuration.Initialization;
using Soenneker.Blazor.Stripe.Elements.Configuration.Card;

namespace Soenneker.Blazor.Stripe.Elements.Configuration;

/// <summary>
/// Master configuration object for orchestrating the creation and mounting of all Stripe Elements.
/// </summary>
public sealed class StripeElementsConfiguration
{
    /// <summary>
    /// The Stripe publishable API key required to initialize Elements.
    /// </summary>
    [JsonPropertyName("publishableKey")]
    public string PublishableKey { get; set; } = null!;

    /// <summary>
    /// Initialization options passed to <c>Stripe(publishableKey, options)</c>.
    /// Includes API version override, locale, developer tools, etc.
    /// </summary>
    [JsonPropertyName("initializationOptions")]
    public StripeInitializationOptions? InitializationOptions { get; set; }

    /// <summary>
    /// Configuration for initializing the Stripe Elements instance itself.
    /// </summary>
    [JsonPropertyName("elementsOptions")]
    public StripeElementsOptions ElementsOptions { get; set; } = new();

    /// <summary>
    /// When set, initializes this group with Stripe's Checkout Sessions Elements SDK instead of <c>stripe.elements()</c>.
    /// </summary>
    [JsonPropertyName("checkoutSessionOptions")]
    public StripeCheckoutSessionOptions? CheckoutSessionOptions { get; set; }

    /// <summary>
    /// The DOM element ID where the Checkout Contact Details Element should be mounted.
    /// </summary>
    [JsonPropertyName("contactDetailsElementId")]
    public string? ContactDetailsElementId { get; set; }

    /// <summary>
    /// Set to mount the Checkout Contact Details Element.
    /// </summary>
    [JsonPropertyName("contactDetailsOptions")]
    public StripeContactDetailsOptions? ContactDetailsOptions { get; set; }

    /// <summary>
    /// The DOM element ID where the Link Authentication Element should be mounted.
    /// </summary>
    [JsonPropertyName("linkAuthenticationElementId")]
    public string? LinkAuthenticationElementId { get; set; }

    /// <summary>
    /// Configuration options for the Link Authentication Element (e.g., default email).
    /// </summary>
    [JsonPropertyName("linkAuthenticationOptions")]
    public StripeLinkAuthenticationOptions? LinkAuthenticationOptions { get; set; }

    /// <summary>
    /// The DOM element ID where the Payment Element should be mounted.
    /// </summary>
    [JsonPropertyName("paymentElementId")]
    public string? PaymentElementId { get; set; }

    /// <summary>
    /// Configuration options for the Payment Element (layout, fields, etc.).
    /// </summary>
    [JsonPropertyName("paymentOptions")]
    public StripePaymentElementOptions? PaymentOptions { get; set; }

    /// <summary>
    /// The DOM element ID where the single-line Card Element should be mounted.
    /// </summary>
    [JsonPropertyName("cardElementId")]
    public string? CardElementId { get; set; }

    /// <summary>
    /// Configuration options for the single-line Card Element, including Link autofill control.
    /// </summary>
    [JsonPropertyName("cardOptions")]
    public StripeCardElementOptions? CardOptions { get; set; }

    /// <summary>
    /// The DOM element ID where the Address Element should be mounted.
    /// </summary>
    [JsonPropertyName("addressElementId")]
    public string? AddressElementId { get; set; }

    /// <summary>
    /// Configuration options for the Address Element (mode, default values, validation, etc.).
    /// </summary>
    [JsonPropertyName("addressOptions")]
    public StripeAddressOptions? AddressOptions { get; set; }
}
