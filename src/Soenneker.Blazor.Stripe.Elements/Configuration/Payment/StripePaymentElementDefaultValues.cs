using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Payment;

/// <summary>
/// Default values to prepopulate customer fields.
/// </summary>
public sealed class StripePaymentElementDefaultValues
{
    [JsonPropertyName("billingDetails")]
    public StripePaymentElementBillingDetails? BillingDetails { get; set; }
}
