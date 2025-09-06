using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Elements;

/// <summary>
/// Additional display options for a custom payment method.
/// </summary>
public sealed class StripeCustomPaymentMethodOptions
{
    /// <summary>
    /// The form type of the custom payment method. Only 'static' is currently supported.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "static";

    /// <summary>
    /// Optional subtitle for the custom method's UI.
    /// </summary>
    [JsonPropertyName("subtitle")]
    public string? Subtitle { get; set; }
}
