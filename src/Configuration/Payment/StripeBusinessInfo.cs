using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Payment;

/// <summary>
/// Represents business identity details for rendering in the Payment Element.
/// </summary>
public class StripeBusinessInfo
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}