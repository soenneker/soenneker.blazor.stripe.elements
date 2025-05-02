using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Appearance;

/// <summary>
/// CSS-like rule definitions for Stripe Elements components.
/// Includes both known targets and extensible support.
/// </summary>
public sealed class StripeAppearanceRulesExtended
{
    /// <summary>Styles for the base input component.</summary>
    [JsonPropertyName(".Input")]
    public StripeInputRule? Input { get; set; }

    /// <summary>Styles when an input is focused.</summary>
    [JsonPropertyName(".Input:focus")]
    public StripeInputRule? InputFocus { get; set; }

    /// <summary>Styles for field labels.</summary>
    [JsonPropertyName(".Label")]
    public StripeLabelRule? Label { get; set; }

    /// <summary>Styles for payment method tabs.</summary>
    [JsonPropertyName(".Tab")]
    public StripeTabRule? Tab { get; set; }

    /// <summary>Styles for selected payment method tab.</summary>
    [JsonPropertyName(".Tab--selected")]
    public StripeTabRule? TabSelected { get; set; }

    /// <summary>
    /// Arbitrary additional rules (e.g., for undocumented or future support).
    /// Keys must be valid CSS selectors like ".CodeField", ".ErrorMessage", etc.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalRules { get; set; }
}