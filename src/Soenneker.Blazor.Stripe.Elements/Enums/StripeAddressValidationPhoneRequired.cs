using Soenneker.Gen.EnumValues;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Validation requirement for the phone field.
/// </summary>
[EnumValue<string>]
public partial class StripeAddressValidationPhoneRequired
{
    // Prevent JSON source generation from assuming an implicit public constructor.
    private StripeAddressValidationPhoneRequired() => throw new System.NotSupportedException("Use a declared enum value.");

    /// <summary>Phone is always required.</summary>
    public static readonly StripeAddressValidationPhoneRequired Always = new("always");

    /// <summary>Phone is required when Stripe deems appropriate.</summary>
    public static readonly StripeAddressValidationPhoneRequired Auto = new("auto");

    /// <summary>Phone is never required.</summary>
    public static readonly StripeAddressValidationPhoneRequired Never = new("never");
}
