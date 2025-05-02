using System.Text.Json.Serialization;
using Soenneker.Blazor.Stripe.Elements.Enums;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Appearance;

/// <summary>
/// Controls the visual theme, layout, and styling of Stripe Elements.
/// </summary>
public sealed class StripeAppearance
{
    /// <summary>
    /// The base theme to use. Supported values: "flat", "night", "none", "stripe".
    /// </summary>
    [JsonPropertyName("theme")]
    public StripeElementsTheme? Theme { get; set; }

    /// <summary>
    /// Controls label behavior. Supported: "above", "floating", or "hidden".
    /// </summary>
    [JsonPropertyName("labels")]
    public StripeLabelsMode? Labels { get; set; }

    /// <summary>
    /// CSS variables used to customize the appearance.
    /// </summary>
    [JsonPropertyName("variables")]
    public StripeAppearanceVariables? Variables { get; set; }

    /// <summary>
    /// CSS rules that target specific Elements components.
    /// </summary>
    [JsonPropertyName("rules")]
    public StripeAppearanceRules? Rules { get; set; }
}