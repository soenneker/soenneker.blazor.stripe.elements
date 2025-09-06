using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Mode for Elements when no Intent is used. Required for payment flows.
/// </summary>
[Intellenum<string>]
public partial class StripeElementsMode
{
    /// <summary>Use for one-time payment collection.</summary>
    public static readonly StripeElementsMode Payment = new("payment");

    /// <summary>Use for collecting and saving payment methods for future use.</summary>
    public static readonly StripeElementsMode Setup = new("setup");

    /// <summary>Use for subscription-based payment setup.</summary>
    public static readonly StripeElementsMode Subscription = new("subscription");
}
