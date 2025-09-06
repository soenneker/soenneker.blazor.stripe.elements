using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// When to show the phone field in the Address Element.
/// </summary>
[Intellenum<string>]
public partial class StripeAddressFieldsPhoneOption
{
    /// <summary>Always show the phone field.</summary>
    public static readonly StripeAddressFieldsPhoneOption Always = new("always");

    /// <summary>Let Stripe decide when to show the phone field.</summary>
    public static readonly StripeAddressFieldsPhoneOption Auto = new("auto");

    /// <summary>Never show the phone field.</summary>
    public static readonly StripeAddressFieldsPhoneOption Never = new("never");
}
