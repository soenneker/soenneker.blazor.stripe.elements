using Soenneker.Gen.EnumValues;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Defines the icon style used by the single-line Card Element.
/// </summary>
[EnumValue<string>]
public partial class StripeCardElementIconStyle
{
    // Prevent JSON source generation from assuming an implicit public constructor.
    private StripeCardElementIconStyle() => throw new System.NotSupportedException("Use a declared enum value.");

    public static readonly StripeCardElementIconStyle Default = new("default");

    public static readonly StripeCardElementIconStyle Solid = new("solid");
}
