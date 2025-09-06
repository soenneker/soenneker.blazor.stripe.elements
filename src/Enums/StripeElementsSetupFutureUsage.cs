using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Indicates whether the collected payment method will be reused and when.
/// </summary>
[Intellenum<string>]
public partial class StripeElementsSetupFutureUsage
{
    /// <summary>Payment method will be reused while the customer is present (in-session).</summary>
    public static readonly StripeElementsSetupFutureUsage OnSession = new("on_session");

    /// <summary>Payment method will be reused off-session (customer not present).</summary>
    public static readonly StripeElementsSetupFutureUsage OffSession = new("off_session");
}
