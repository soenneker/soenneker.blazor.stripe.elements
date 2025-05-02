using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration;

/// <summary>
/// Represents the per-Element styling configuration for Stripe Elements.
/// Supports variant-based styling for input states.
/// </summary>
public sealed class StripeElementStyle
{
    /// <summary>
    /// Base styles applied to the Element. All other variants inherit from this unless overridden.
    /// </summary>
    [JsonPropertyName("base")]
    public Dictionary<string, object>? Base { get; set; }

    /// <summary>
    /// Styles applied when the Element has valid and complete input.
    /// </summary>
    [JsonPropertyName("complete")]
    public Dictionary<string, object>? Complete { get; set; }

    /// <summary>
    /// Styles applied when the Element is empty (no user input).
    /// </summary>
    [JsonPropertyName("empty")]
    public Dictionary<string, object>? Empty { get; set; }

    /// <summary>
    /// Styles applied when the Element's input is invalid.
    /// </summary>
    [JsonPropertyName("invalid")]
    public Dictionary<string, object>? Invalid { get; set; }
}