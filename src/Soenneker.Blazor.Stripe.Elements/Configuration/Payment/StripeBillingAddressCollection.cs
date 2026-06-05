using System.Text.Json.Serialization;
using Soenneker.Blazor.Stripe.Elements.Enums;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Payment;

/// <summary>
/// Controls which billing address fields are collected.
/// </summary>
public class StripeBillingAddressCollection
{
    /// <summary>
    /// Gets or sets line1.
    /// </summary>
    [JsonPropertyName("line1")]
    public StripeBillingAddressFieldOption? Line1 { get; set; } = StripeBillingAddressFieldOption.Auto;

    /// <summary>
    /// Gets or sets line2.
    /// </summary>
    [JsonPropertyName("line2")]
    public StripeBillingAddressFieldOption? Line2 { get; set; } = StripeBillingAddressFieldOption.Auto;

    /// <summary>
    /// Gets or sets city.
    /// </summary>
    [JsonPropertyName("city")]
    public StripeBillingAddressFieldOption? City { get; set; } = StripeBillingAddressFieldOption.Auto;

    /// <summary>
    /// Gets or sets state.
    /// </summary>
    [JsonPropertyName("state")]
    public StripeBillingAddressFieldOption? State { get; set; } = StripeBillingAddressFieldOption.Auto;

    /// <summary>
    /// Gets or sets country.
    /// </summary>
    [JsonPropertyName("country")]
    public StripeBillingAddressFieldOption? Country { get; set; } = StripeBillingAddressFieldOption.Auto;

    /// <summary>
    /// Gets or sets postal code.
    /// </summary>
    [JsonPropertyName("postalCode")]
    public StripeBillingAddressFieldOption? PostalCode { get; set; } = StripeBillingAddressFieldOption.Auto;
}
