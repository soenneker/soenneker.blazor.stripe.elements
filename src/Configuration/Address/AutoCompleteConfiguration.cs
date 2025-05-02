using System.Text.Json.Serialization;
using Soenneker.Blazor.Stripe.Elements.Enums;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Address;

/// <summary>
/// Configuration for autocomplete behavior.
/// </summary>
public class AutocompleteConfiguration
{
    /// <summary>
    /// Mode for autocomplete: 'automatic', 'disabled', or 'google_maps_api'.
    /// </summary>
    [JsonPropertyName("mode")]
    public StripeAddressAutocompleteMode Mode { get; set; } = StripeAddressAutocompleteMode.Automatic;

    /// <summary>
    /// Optional Google Maps API key, required if mode is 'google_maps_api'.
    /// </summary>
    [JsonPropertyName("apiKey")]
    public string? ApiKey { get; set; }
}