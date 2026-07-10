using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Card;

/// <summary>
/// Billing details attached when confirming a PaymentIntent or SetupIntent with the Card Element.
/// </summary>
public sealed class StripeCardBillingDetails
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("address")]
    public StripeAddressDetails? Address { get; set; }
}
