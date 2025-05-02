using Soenneker.Blazor.Stripe.Elements.Configuration.LinkAuthentication;
using Soenneker.Blazor.Stripe.Elements.Configuration.Payment;
using Soenneker.Blazor.Stripe.Elements.Configuration.Address;
using System.Text.Json.Serialization;
using Soenneker.Blazor.Stripe.Elements.Configuration.Elements;
using Soenneker.Blazor.Stripe.Elements.Configuration.Initialization;

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
    /// Configuration for initializing the Stripe Elements instance itself (fonts, appearance, locale, etc.).
    /// </summary>
    [JsonPropertyName("elementsOptions")]
    public StripeElementsOptions ElementsOptions { get; set; } = new();

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