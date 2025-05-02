using System.Text.Json.Serialization;
using Soenneker.Blazor.Stripe.Elements.Enums;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Payment;

/// <summary>
/// Controls which billing address fields are collected.
/// </summary>
public class StripeBillingAddressCollection
{
    [JsonPropertyName("line1")]
    public StripeBillingAddressFieldOption? Line1 { get; set; } = StripeBillingAddressFieldOption.Auto;

    [JsonPropertyName("line2")]
    public StripeBillingAddressFieldOption? Line2 { get; set; } = StripeBillingAddressFieldOption.Auto;

    [JsonPropertyName("city")]
    public StripeBillingAddressFieldOption? City { get; set; } = StripeBillingAddressFieldOption.Auto;

    [JsonPropertyName("state")]
    public StripeBillingAddressFieldOption? State { get; set; } = StripeBillingAddressFieldOption.Auto;

    [JsonPropertyName("country")]
    public StripeBillingAddressFieldOption? Country { get; set; } = StripeBillingAddressFieldOption.Auto;

    [JsonPropertyName("postalCode")]
    public StripeBillingAddressFieldOption? PostalCode { get; set; } = StripeBillingAddressFieldOption.Auto;
}