using Soenneker.Blazor.Stripe.Elements.Enums;
using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration;

public class StripeJsConfiguration
{
    [JsonPropertyName("mode")]
    public StripeElementsMode Mode { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }
}