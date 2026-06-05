using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Payment;

/// <summary>
/// Apple Pay-specific configuration.
/// </summary>
public class StripeApplePayOptions
{
    /// <summary>
    /// Gets or sets recurring payment request.
    /// </summary>
    [JsonPropertyName("recurringPaymentRequest")]
    public object? RecurringPaymentRequest { get; set; }

    /// <summary>
    /// Gets or sets deferred payment request.
    /// </summary>
    [JsonPropertyName("deferredPaymentRequest")]
    public object? DeferredPaymentRequest { get; set; }

    /// <summary>
    /// Gets or sets automatic reload payment request.
    /// </summary>
    [JsonPropertyName("automaticReloadPaymentRequest")]
    public object? AutomaticReloadPaymentRequest { get; set; }
}
