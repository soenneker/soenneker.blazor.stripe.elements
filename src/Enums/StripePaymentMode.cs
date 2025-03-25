using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

[Intellenum<string>]
public partial class StripeElementsMode
{
    public static readonly StripeElementsMode Payment = new("payment");
    public static readonly StripeElementsMode Setup = new("setup");
    public static readonly StripeElementsMode Subscription = new("subscription");
}