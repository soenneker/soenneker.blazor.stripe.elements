using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Controls how payment authorization is captured.
/// </summary>
[Intellenum<string>]
public partial class StripeElementsCaptureMethod
{
    /// <summary>Capture payment automatically when authorized.</summary>
    public static readonly StripeElementsCaptureMethod Automatic = new("automatic");

    /// <summary>Capture payment automatically but allow async confirmation (e.g., for delayed pay methods).</summary>
    public static readonly StripeElementsCaptureMethod AutomaticAsync = new("automatic_async");

    /// <summary>Require manual capture of the payment after authorization.</summary>
    public static readonly StripeElementsCaptureMethod Manual = new("manual");
}