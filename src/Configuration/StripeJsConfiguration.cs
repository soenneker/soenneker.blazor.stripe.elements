using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration;

public class StripeJsConfiguration
{
    [JsonPropertyName("mode")]
    public string Mode { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }
}