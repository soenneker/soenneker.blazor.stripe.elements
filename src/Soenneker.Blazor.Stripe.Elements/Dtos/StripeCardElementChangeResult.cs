using System.Text.Json.Serialization;
using Soenneker.Dtos.Stripe.Error;

namespace Soenneker.Blazor.Stripe.Elements.Dtos;

/// <summary>
/// State reported by Stripe when the Card Element value changes.
/// </summary>
public sealed class StripeCardElementChangeResult
{
    [JsonPropertyName("complete")]
    public bool Complete { get; set; }

    [JsonPropertyName("empty")]
    public bool Empty { get; set; }

    [JsonPropertyName("brand")]
    public string? Brand { get; set; }

    [JsonPropertyName("error")]
    public StripeErrorDto? Error { get; set; }
}
