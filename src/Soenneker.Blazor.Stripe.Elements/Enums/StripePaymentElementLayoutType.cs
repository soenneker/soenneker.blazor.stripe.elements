using Soenneker.Gen.EnumValues;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Defines the layout type for the Stripe Payment Element: "accordion" or "tabs".
/// </summary>
[EnumValue<string>]
public partial class StripePaymentElementLayoutType
{
    // Prevent JSON source generation from assuming an implicit public constructor.
    private StripePaymentElementLayoutType() => throw new System.NotSupportedException("Use a declared enum value.");

    /// <summary>
    /// The accordion.
    /// </summary>
    public static readonly StripePaymentElementLayoutType Accordion = new("accordion");
    /// <summary>
    /// The tabs.
    /// </summary>
    public static readonly StripePaymentElementLayoutType Tabs = new("tabs");
}
