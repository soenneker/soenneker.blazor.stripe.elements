using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Stripe Elements base theme. Defines default styles for all components.
/// </summary>
[Intellenum<string>]
public partial class StripeElementsTheme
{
    /// <summary>The default Stripe theme.</summary>
    public static readonly StripeElementsTheme Stripe = new("stripe");

    /// <summary>A simplified flat appearance.</summary>
    public static readonly StripeElementsTheme Flat = new("flat");

    /// <summary>A dark mode theme with high contrast.</summary>
    public static readonly StripeElementsTheme Night = new("night");

    /// <summary>No theme applied. Fully custom styling.</summary>
    public static readonly StripeElementsTheme None = new("none");
}
