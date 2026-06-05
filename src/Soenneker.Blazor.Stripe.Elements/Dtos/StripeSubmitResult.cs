using System.Text.Json.Serialization;
using Soenneker.Dtos.Stripe.Error;

namespace Soenneker.Blazor.Stripe.Elements.Dtos;

/// <summary>
/// Represents the stripe submit result.
/// </summary>
public sealed class StripeSubmitResult
{
    /// <summary>
    /// Gets or sets error.
    /// </summary>
    [JsonPropertyName("error")]
    public StripeErrorDto? Error { get; set; }
}
