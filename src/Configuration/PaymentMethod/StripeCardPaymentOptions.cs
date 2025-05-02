using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.PaymentMethod;

/// <summary>
/// Configuration options for card-based payment methods.
/// </summary>
public sealed class StripeCardPaymentOptions
{
    /// <summary>
    /// When true, requires CVC recollection when using a saved card with a customer.
    /// </summary>
    [JsonPropertyName("require_cvc_recollection")]
    public bool? RequireCvcRecollection { get; set; }

    /// <summary>
    /// Installment plan configuration for card payments.
    /// </summary>
    [JsonPropertyName("installments")]
    public StripeCardInstallmentOptions? Installments { get; set; }
}