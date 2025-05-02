using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Controls the behavior of individual billing address fields in the Payment Element.
/// </summary>
[Intellenum<string>]
public partial class StripeBillingAddressFieldOption
{
    /// <summary>Let Stripe determine whether to collect the field (default).</summary>
    public static readonly StripeBillingAddressFieldOption Auto = new("auto");

    /// <summary>Never collect this billing address field.</summary>
    public static readonly StripeBillingAddressFieldOption Never = new("never");
}