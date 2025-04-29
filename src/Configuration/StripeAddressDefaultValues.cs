using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration;

public sealed class StripeAddressDefaultValues
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("address")]
    public StripeAddressDetails? Address { get; set; }
}