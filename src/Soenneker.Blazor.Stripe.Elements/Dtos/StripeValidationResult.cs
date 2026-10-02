using Soenneker.Stripe.Dtos.JsError;
using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Dtos;

/// <summary>
/// Represents the result of a call to <c>elements.submit()</c> for validating Stripe Elements input.
/// </summary>
public sealed class StripeValidationResult
{
    /// <summary>
    /// The validation error returned by Stripe, if any.
    /// </summary>
    [JsonPropertyName("error")]
    public StripeJsError? Error { get; set; }
}
