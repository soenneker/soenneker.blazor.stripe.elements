using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Payment;

/// <summary>
/// Default values to prepopulate customer fields.
/// </summary>
public class StripeDefaultCustomerValues
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("address")]
    public StripeAddressDetails? Address { get; set; }
}