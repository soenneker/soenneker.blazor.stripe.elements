using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Payment;

/// <summary>
/// Apple Pay-specific configuration.
/// </summary>
public class StripeApplePayOptions
{
    [JsonPropertyName("recurringPaymentRequest")]
    public object? RecurringPaymentRequest { get; set; }

    [JsonPropertyName("deferredPaymentRequest")]
    public object? DeferredPaymentRequest { get; set; }

    [JsonPropertyName("automaticReloadPaymentRequest")]
    public object? AutomaticReloadPaymentRequest { get; set; }
}
