using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Elements;

/// <summary>
/// Defines a custom font to be used in Stripe Elements.
/// </summary>
public sealed class StripeFontSource
{
    /// <summary>
    /// A publicly hosted CSS file URL containing @font-face rules.
    /// </summary>
    [JsonPropertyName("cssSrc")]
    public string? CssSrc { get; set; }

    /// <summary>
    /// The font-family name to be used in CSS.
    /// </summary>
    [JsonPropertyName("family")]
    public string? Family { get; set; }

    /// <summary>
    /// A direct URL to the font file (e.g., .woff2).
    /// </summary>
    [JsonPropertyName("src")]
    public string? Src { get; set; }

    /// <summary>
    /// The font style (e.g., 'normal', 'italic').
    /// </summary>
    [JsonPropertyName("style")]
    public string? Style { get; set; }

    /// <summary>
    /// A comma-separated list of Unicode ranges to load.
    /// </summary>
    [JsonPropertyName("unicodeRange")]
    public string? UnicodeRange { get; set; }

    /// <summary>
    /// The font weight (e.g., '400', 'bold').
    /// </summary>
    [JsonPropertyName("weight")]
    public string? Weight { get; set; }
}