using Soenneker.Gen.EnumValues;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Defines the icon style used by the single-line Card Element.
/// </summary>
[EnumValue<string>]
public partial class StripeCardElementIconStyle
{
    public static readonly StripeCardElementIconStyle Default = new("default");

    public static readonly StripeCardElementIconStyle Solid = new("solid");
}
