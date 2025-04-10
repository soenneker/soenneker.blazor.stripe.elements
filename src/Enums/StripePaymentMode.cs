using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

[Intellenum<string>]
public partial class StripeElementsMode
{
    public static readonly StripeElementsMode Payment = new("payment");
    public static readonly StripeElementsMode Setup = new("setup");
    public static readonly StripeElementsMode Subscription = new("subscription");
    public static readonly StripeElementsMode OffSession = new("off_session");
    public static readonly StripeElementsMode OnSession = new("on_session");
}