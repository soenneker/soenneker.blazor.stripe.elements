using Soenneker.Blazor.Stripe.Elements.Enums;
using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration;

public sealed class StripeJsConfiguration
{
    [JsonPropertyName("mode")]
    public StripeElementsMode Mode { get; set; } = null!;

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = null!;

    [JsonPropertyName("amount")]
    public int Amount { get; set; }
}