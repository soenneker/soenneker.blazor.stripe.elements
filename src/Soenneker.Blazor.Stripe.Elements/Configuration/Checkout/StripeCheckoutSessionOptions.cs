using System.Text.Json.Serialization;
using Soenneker.Blazor.Stripe.Elements.Configuration.Elements;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Checkout;

/// <summary>
/// Options for initializing Stripe's Checkout Sessions Elements SDK.
/// </summary>
public sealed class StripeCheckoutSessionOptions
{
    /// <summary>
    /// The Checkout Session client secret returned by the server.
    /// </summary>
    [JsonPropertyName("clientSecret")]
    public string? ClientSecret { get; set; }

    /// <summary>
    /// Options passed to the underlying Elements factory used by Checkout.
    /// </summary>
    [JsonPropertyName("elementsOptions")]
    public StripeElementsOptions? ElementsOptions { get; set; }

    /// <summary>
    /// Default customer details used by the Checkout Elements SDK.
    /// </summary>
    [JsonPropertyName("defaultValues")]
    public StripeCheckoutDefaultValues? DefaultValues { get; set; }

    /// <summary>
    /// Enables Stripe adaptive pricing for supported Checkout Sessions.
    /// </summary>
    [JsonPropertyName("adaptivePricing")]
    public bool? AdaptivePricing { get; set; }

    /// <summary>
    /// Controls display of a sync-address checkbox when supported by the Checkout Elements SDK.
    /// </summary>
    [JsonPropertyName("syncAddressCheckbox")]
    public string? SyncAddressCheckbox { get; set; }
}
