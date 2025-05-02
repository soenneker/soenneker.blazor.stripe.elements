using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Payment;

/// <summary>
/// Controls which billing fields are collected in the Payment Element.
/// </summary>
public class StripePaymentFields
{
    [JsonPropertyName("billingDetails")]
    public StripeBillingDetailsCollection? BillingDetails { get; set; }
}