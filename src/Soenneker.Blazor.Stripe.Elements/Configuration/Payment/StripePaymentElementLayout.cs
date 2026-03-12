using System.Text.Json.Serialization;
using Soenneker.Blazor.Stripe.Elements.Enums;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Payment;

/// <summary>
/// Represents the layout configuration for the Stripe Payment Element.
/// </summary>
public class StripePaymentElementLayout
{
    /// <summary>
    /// Defines the layout type: "accordion" or "tabs".
    /// </summary>
    [JsonPropertyName("type")]
    public StripePaymentElementLayoutType Type { get; set; } = StripePaymentElementLayoutType.Accordion;

    /// <summary>
    /// When true, renders the Payment Element in a collapsed state (no method selected by default).
    /// </summary>
    [JsonPropertyName("defaultCollapsed")]
    public bool? DefaultCollapsed { get; set; }

    /// <summary>
    /// When true, renders radio inputs next to each payment method (only for "accordion").
    /// </summary>
    [JsonPropertyName("radios")]
    public bool? Radios { get; set; }

    /// <summary>
    /// When true, renders payment methods with spacing as separate buttons (only for "accordion").
    /// </summary>
    [JsonPropertyName("spacedAccordionItems")]
    public bool? SpacedAccordionItems { get; set; }

    /// <summary>
    /// Maximum number of payment methods visible before "More" is used. 0 disables the "More" button. Default is 5. (only for "accordion")
    /// </summary>
    [JsonPropertyName("visibleAccordionItemsCount")]
    public int? VisibleAccordionItemsCount { get; set; }
}
