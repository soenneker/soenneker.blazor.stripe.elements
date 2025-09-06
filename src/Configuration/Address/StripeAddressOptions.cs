using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Address;

/// <summary>
/// Configuration for Stripe's Address Element.
/// </summary>
public class StripeAddressOptions
{
    /// <summary>
    /// Specifies whether the Address Element is used for 'shipping' or 'billing'.
    /// </summary>
    [JsonPropertyName("mode")]
    public Enums.StripeAddressMode Mode { get; set; } = Enums.StripeAddressMode.Billing;

    /// <summary>
    /// Configuration for the autocomplete behavior of the Address Element.
    /// </summary>
    [JsonPropertyName("autocomplete")]
    public AutocompleteConfiguration? Autocomplete { get; set; }

    /// <summary>
    /// Specifies which two-letter country codes are shown in the dropdown.
    /// </summary>
    [JsonPropertyName("allowedCountries")]
    public List<string>? AllowedCountries { get; set; }

    /// <summary>
    /// Whether PO Boxes should be blocked from submission.
    /// </summary>
    [JsonPropertyName("blockPoBox")]
    public bool? BlockPoBox { get; set; }

    /// <summary>
    /// A list of predefined contacts that can be used to prefill the form.
    /// </summary>
    [JsonPropertyName("contacts")]
    public List<StripeAddressContact>? Contacts { get; set; }

    /// <summary>
    /// Default values to populate the address form with.
    /// </summary>
    [JsonPropertyName("defaultValues")]
    public StripeAddressDefaultValues? DefaultValues { get; set; }

    /// <summary>
    /// Customization options for field visibility and behavior.
    /// </summary>
    [JsonPropertyName("fields")]
    public StripeAddressFields? Fields { get; set; }

    /// <summary>
    /// Custom validation rules for specific fields.
    /// </summary>
    [JsonPropertyName("validation")]
    public StripeAddressValidation? Validation { get; set; }

    /// <summary>
    /// Custom display configuration for how name fields appear.
    /// </summary>
    [JsonPropertyName("display")]
    public StripeAddressDisplay? Display { get; set; }

    /// <summary>
    /// CSS-like styling rules for the Address Element (base, invalid, etc).
    /// </summary>
    [JsonPropertyName("style")]
    public StripeElementStyle? Style { get; set; }
}
