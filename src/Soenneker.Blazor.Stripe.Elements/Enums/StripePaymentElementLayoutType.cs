using Soenneker.Gen.EnumValues;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Defines the layout type for the Stripe Payment Element: "accordion" or "tabs".
/// </summary>
[EnumValue<string>]
public partial class StripePaymentElementLayoutType
{
    /// <summary>
    /// The accordion.
    /// </summary>
    public static readonly StripePaymentElementLayoutType Accordion = new("accordion");
    /// <summary>
    /// The tabs.
    /// </summary>
    public static readonly StripePaymentElementLayoutType Tabs = new("tabs");
}
