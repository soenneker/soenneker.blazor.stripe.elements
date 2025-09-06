namespace Soenneker.Blazor.Stripe.Elements.Configuration.Appearance;

/// <summary>
/// Style properties for tab elements.
/// </summary>
public sealed class StripeTabRule
{
    /// <summary>Text color or selected state color.</summary>
    public string? Color { get; set; }

    /// <summary>Border style (e.g., "1px solid #ccc").</summary>
    public string? Border { get; set; }

    /// <summary>Border color (shorthand for border customization).</summary>
    public string? BorderColor { get; set; }
}
