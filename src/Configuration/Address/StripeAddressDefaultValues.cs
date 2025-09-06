using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Address;

/// <summary>
/// Default values used to prefill the Address Element.
/// </summary>
public class StripeAddressDefaultValues
{
    /// <summary>
    /// Full name or organization name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// First name. Requires display.name = 'split'.
    /// </summary>
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    /// <summary>
    /// Last name. Requires display.name = 'split'.
    /// </summary>
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    /// <summary>
    /// Phone number. Requires fields.phone = 'always'.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Default address details.
    /// </summary>
    [JsonPropertyName("address")]
    public StripeAddressDetails? Address { get; set; }
}
