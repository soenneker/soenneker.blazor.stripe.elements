using Soenneker.Blazor.Stripe.Elements.Enums;
using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Payment;

/// <summary>
/// Controls the inclusion of specific billing details in the Payment Element.
/// </summary>
public class StripeBillingDetailsCollection
{
    /// <summary>
    /// Whether to collect the customer's name.
    /// </summary>
    [JsonPropertyName("name")]
    public StripeBillingAddressFieldOption Name { get; set; } = StripeBillingAddressFieldOption.Auto;

    /// <summary>
    /// Whether to collect the customer's email.
    /// </summary>
    [JsonPropertyName("email")]
    public StripeBillingAddressFieldOption Email { get; set; } = StripeBillingAddressFieldOption.Auto;

    /// <summary>
    /// Whether to collect the customer's phone number.
    /// </summary>
    [JsonPropertyName("phone")]
    public StripeBillingAddressFieldOption Phone { get; set; } = StripeBillingAddressFieldOption.Auto;

    /// <summary>
    /// Controls collection of billing address fields (line1, postal code, etc.).
    /// Supports per-field control or general rules like 'auto', 'never', or 'if_required'.
    /// </summary>
    [JsonPropertyName("address")]
    public StripeBillingAddressCollection? Address { get; set; }
}
