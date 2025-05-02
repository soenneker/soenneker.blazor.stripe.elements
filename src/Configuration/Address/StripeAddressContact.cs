using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Address;

/// <summary>
/// Represents a saved contact with name, phone, and address.
/// </summary>
public class StripeAddressContact
{
    /// <summary>
    /// Full name or organization.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Phone number associated with the contact.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Address associated with the contact.
    /// </summary>
    [JsonPropertyName("address")]
    public StripeAddressDetails? Address { get; set; }
}