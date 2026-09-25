using Soenneker.Gen.EnumValues;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Mode of the Address Element — determines how the address is used.
/// </summary>
[EnumValue<string>]
public partial class StripeAddressMode
{
    // Prevent JSON source generation from assuming an implicit public constructor.
    private StripeAddressMode() => throw new System.NotSupportedException("Use a declared enum value.");

    /// <summary>Use the address as a shipping address.</summary>
    public static readonly StripeAddressMode Shipping = new("shipping");

    /// <summary>Use the address as a billing address.</summary>
    public static readonly StripeAddressMode Billing = new("billing");
}
