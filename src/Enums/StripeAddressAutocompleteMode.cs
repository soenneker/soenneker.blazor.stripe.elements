using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// The autocomplete mode for the Stripe Address Element.
/// </summary>
[Intellenum<string>]
public partial class StripeAddressAutocompleteMode
{
    /// <summary>Enable Stripe’s default automatic behavior.</summary>
    public static readonly StripeAddressAutocompleteMode Automatic = new("automatic");

    /// <summary>Completely disable autocomplete in the Address Element.</summary>
    public static readonly StripeAddressAutocompleteMode Disabled = new("disabled");

    /// <summary>Enable autocomplete using your own Google Maps API key.</summary>
    public static readonly StripeAddressAutocompleteMode GoogleMapsApi = new("google_maps_api");
}