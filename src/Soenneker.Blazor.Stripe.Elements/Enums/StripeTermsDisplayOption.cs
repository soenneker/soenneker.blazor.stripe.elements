using Soenneker.Gen.EnumValues;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// When to display terms or mandate agreements in the Payment Element.
/// </summary>
[EnumValue<string>]
public partial class StripeTermsDisplayOption
{
    // Prevent JSON source generation from assuming an implicit public constructor.
    private StripeTermsDisplayOption() => throw new System.NotSupportedException("Use a declared enum value.");

    /// <summary>Let Stripe determine if terms are needed (default).</summary>
    public static readonly StripeTermsDisplayOption Auto = new("auto");

    /// <summary>Always show the agreement UI.</summary>
    public static readonly StripeTermsDisplayOption Always = new("always");

    /// <summary>Never show mandate/terms agreements.</summary>
    public static readonly StripeTermsDisplayOption Never = new("never");
}
