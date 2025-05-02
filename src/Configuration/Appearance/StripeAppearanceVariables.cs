namespace Soenneker.Blazor.Stripe.Elements.Configuration.Appearance;

/// <summary>
/// Common styling variables used in Stripe Elements themes.
/// </summary>
public class StripeAppearanceVariables
{
    /// <summary>Primary accent color.</summary>
    public string? ColorPrimary { get; set; }

    /// <summary>Background color for inputs and components.</summary>
    public string? ColorBackground { get; set; }

    /// <summary>Default text color.</summary>
    public string? ColorText { get; set; }

    /// <summary>Color used for error states.</summary>
    public string? ColorDanger { get; set; }

    /// <summary>Font family to apply across elements.</summary>
    public string? FontFamily { get; set; }

    /// <summary>Spacing unit used for padding/margins.</summary>
    public string? SpacingUnit { get; set; }

    /// <summary>Border radius for components.</summary>
    public string? BorderRadius { get; set; }
}