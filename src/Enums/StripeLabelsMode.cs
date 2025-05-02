using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Controls label behavior for Stripe Elements fields.
/// </summary>
[Intellenum<string>]
public partial class StripeLabelsMode
{
    /// <summary>Labels appear above form fields.</summary>
    public static readonly StripeLabelsMode Above = new("above");

    /// <summary>Labels float within the form fields.</summary>
    public static readonly StripeLabelsMode Floating = new("floating");

    /// <summary>Labels are hidden entirely.</summary>
    public static readonly StripeLabelsMode Hidden = new("hidden");
}