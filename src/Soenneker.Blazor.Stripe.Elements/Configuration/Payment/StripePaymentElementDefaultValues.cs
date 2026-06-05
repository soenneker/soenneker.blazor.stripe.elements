using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Payment;

/// <summary>
/// Default values to prepopulate customer fields.
/// </summary>
public sealed class StripePaymentElementDefaultValues
{
    /// <summary>
    /// Gets or sets billing details.
    /// </summary>
    [JsonPropertyName("billingDetails")]
    public StripePaymentElementBillingDetails? BillingDetails { get; set; }
}
