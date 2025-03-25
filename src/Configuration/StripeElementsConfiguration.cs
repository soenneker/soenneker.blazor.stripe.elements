using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration;

public class StripeElementsConfiguration
{
    [JsonPropertyName("customerName")]
    public string CustomerName { get; set; }

    [JsonPropertyName("customerEmail")]
    public string CustomerEmail { get; set; }

    [JsonPropertyName("publishableKey")]
    public string PublishableKey { get; set; }

    [JsonPropertyName("stripeConfiguration")]
    public StripeJsConfiguration StripeJsConfiguration { get; set; }

    [JsonPropertyName("linkAuthenticationElementId")]
    public string? LinkAuthenticationElementId { get; set; }

    [JsonPropertyName("paymentElementId")]
    public string? PaymentElementId { get; set; }

    [JsonPropertyName("addressElementId")]
    public string? AddressElementId { get; set; }
}