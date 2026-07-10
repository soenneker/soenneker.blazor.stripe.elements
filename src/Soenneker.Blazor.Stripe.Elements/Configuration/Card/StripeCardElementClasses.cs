using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Card;

/// <summary>
/// CSS classes applied to the Card Element container as its state changes.
/// </summary>
public sealed class StripeCardElementClasses
{
    [JsonPropertyName("base")]
    public string? Base { get; set; }

    [JsonPropertyName("complete")]
    public string? Complete { get; set; }

    [JsonPropertyName("empty")]
    public string? Empty { get; set; }

    [JsonPropertyName("focus")]
    public string? Focus { get; set; }

    [JsonPropertyName("invalid")]
    public string? Invalid { get; set; }

    [JsonPropertyName("webkitAutofill")]
    public string? WebkitAutofill { get; set; }
}
