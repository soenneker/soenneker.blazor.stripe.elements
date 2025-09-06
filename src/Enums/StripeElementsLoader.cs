using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Controls when the skeleton loader is displayed for Elements.
/// </summary>
[Intellenum<string>]
public partial class StripeElementsLoader
{
    /// <summary>Let Stripe decide when to show the loader.</summary>
    public static readonly StripeElementsLoader Auto = new("auto");

    /// <summary>Always show the loader.</summary>
    public static readonly StripeElementsLoader Always = new("always");

    /// <summary>Never show the loader.</summary>
    public static readonly StripeElementsLoader Never = new("never");
}
