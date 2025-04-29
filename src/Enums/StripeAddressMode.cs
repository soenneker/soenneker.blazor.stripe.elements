using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

[Intellenum<string>]
public partial class StripeAddressMode
{
    public static readonly StripeAddressMode Shipping = new("shipping");
    public static readonly StripeAddressMode Billing = new("billing");
}