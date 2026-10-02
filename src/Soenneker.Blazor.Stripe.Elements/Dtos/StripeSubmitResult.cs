using Soenneker.Stripe.Dtos.JsError;
using System.Text.Json.Serialization;

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
    public StripeJsError? Error { get; set; }
}
