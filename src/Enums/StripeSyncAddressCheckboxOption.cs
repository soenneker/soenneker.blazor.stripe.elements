using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Which Address Element (if any) should display a checkbox for syncing billing/shipping.
/// </summary>
[Intellenum<string>]
public partial class StripeSyncAddressCheckboxOption
{
    /// <summary>Show the checkbox in the billing Address Element.</summary>
    public static readonly StripeSyncAddressCheckboxOption Billing = new("billing");

    /// <summary>Show the checkbox in the shipping Address Element.</summary>
    public static readonly StripeSyncAddressCheckboxOption Shipping = new("shipping");

    /// <summary>Do not show the sync address checkbox in any Address Element.</summary>
    public static readonly StripeSyncAddressCheckboxOption None = new("none");
}