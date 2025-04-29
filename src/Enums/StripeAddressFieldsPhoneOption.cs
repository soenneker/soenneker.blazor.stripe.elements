using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

[Intellenum<string>]
public partial class StripeAddressFieldsPhoneOption
{
    public static readonly StripeAddressFieldsPhoneOption Always = new("always");
    public static readonly StripeAddressFieldsPhoneOption Auto = new("auto");
    public static readonly StripeAddressFieldsPhoneOption Never = new("never");
}