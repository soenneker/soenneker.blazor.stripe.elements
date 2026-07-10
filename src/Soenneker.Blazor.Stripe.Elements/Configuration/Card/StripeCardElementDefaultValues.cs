using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Card;

/// <summary>
/// Initial values supported by Stripe's Card Element.
/// </summary>
public sealed class StripeCardElementDefaultValues
{
    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }
}
