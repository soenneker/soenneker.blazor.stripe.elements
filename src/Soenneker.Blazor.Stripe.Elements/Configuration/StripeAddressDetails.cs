using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration;

/// <summary>
/// Details for a postal address.
/// </summary>
public sealed class StripeAddressDetails
{
    /// <summary>
    /// Address line 1 (e.g., street address).
    /// </summary>
    [JsonPropertyName("line1")]
    public string? Line1 { get; set; }

    /// <summary>
    /// Address line 2 (e.g., apartment, suite).
    /// </summary>
    [JsonPropertyName("line2")]
    public string? Line2 { get; set; }

    /// <summary>
    /// City or locality.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// State, province, or region.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// ZIP or postal code.
    /// </summary>
    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; set; }

    /// <summary>
    /// Two-letter country code (e.g., "US").
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }
}
