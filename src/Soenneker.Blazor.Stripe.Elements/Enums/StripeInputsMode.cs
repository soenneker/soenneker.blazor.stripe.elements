using Soenneker.Gen.EnumValues;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Controls how related input fields are arranged in Stripe Elements.
/// </summary>
[EnumValue<string>]
public partial class StripeInputsMode
{
    /// <summary>Displays each input with space around it.</summary>
    public static readonly StripeInputsMode Spaced = new("spaced");

    /// <summary>Groups related inputs together into a compact control.</summary>
    public static readonly StripeInputsMode Condensed = new("condensed");
}
