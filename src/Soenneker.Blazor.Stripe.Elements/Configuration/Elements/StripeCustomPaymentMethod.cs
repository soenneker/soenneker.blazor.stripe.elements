using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Elements;

/// <summary>
/// A custom payment method configuration to display in the Payment Element.
/// Must be registered in the Stripe Dashboard.
/// </summary>
public sealed class StripeCustomPaymentMethod
{
    /// <summary>
    /// The ID of the custom payment method (must be prefixed with 'cpmt_').
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    /// <summary>
    /// Options to configure how the custom payment method is displayed.
    /// </summary>
    [JsonPropertyName("options")]
    public StripeCustomPaymentMethodOptions Options { get; set; } = new();
}
