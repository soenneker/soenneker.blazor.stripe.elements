using Soenneker.Gen.EnumValues;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Controls how related input fields are arranged in Stripe Elements.
/// </summary>
[EnumValue<string>]
public partial class StripeInputsMode
{
    // Prevent JSON source generation from assuming an implicit public constructor.
    private StripeInputsMode() => throw new System.NotSupportedException("Use a declared enum value.");

    /// <summary>Displays each input with space around it.</summary>
    public static readonly StripeInputsMode Spaced = new("spaced");

    /// <summary>Groups related inputs together into a compact control.</summary>
    public static readonly StripeInputsMode Condensed = new("condensed");
}
