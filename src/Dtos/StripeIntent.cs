using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Dtos;

public sealed class StripeIntent
{
    /// <summary>
    /// The unique ID of the intent object (e.g. <c>pi_...</c> or <c>seti_...</c>).
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The status of the intent (e.g. <c>succeeded</c>, <c>requires_action</c>, etc.).
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}