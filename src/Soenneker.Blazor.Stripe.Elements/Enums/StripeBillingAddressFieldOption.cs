using Soenneker.Gen.EnumValues;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Controls the behavior of individual billing address fields in the Payment Element.
/// </summary>
[EnumValue<string>]
public sealed partial class StripeBillingAddressFieldOption
{
    // Prevent JSON source generation from assuming an implicit public constructor.
    private StripeBillingAddressFieldOption() => throw new System.NotSupportedException("Use a declared enum value.");

    /// <summary>Let Stripe determine whether to collect the field (default).</summary>
    public static readonly StripeBillingAddressFieldOption Auto = new("auto");

    /// <summary>Never collect this billing address field.</summary>
    public static readonly StripeBillingAddressFieldOption Never = new("never");
}
