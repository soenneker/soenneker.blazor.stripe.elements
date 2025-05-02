using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.PaymentMethod;

/// <summary>
/// Controls whether the card installment selection UI should be displayed (issuer/country-dependent).
/// </summary>
public sealed class StripeCardInstallmentOptions
{
    /// <summary>
    /// When true, enables the installment plan selector.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }
}