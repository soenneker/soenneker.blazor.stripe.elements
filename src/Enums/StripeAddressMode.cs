using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Mode of the Address Element — determines how the address is used.
/// </summary>
[Intellenum<string>]
public partial class StripeAddressMode
{
    /// <summary>Use the address as a shipping address.</summary>
    public static readonly StripeAddressMode Shipping = new("shipping");

    /// <summary>Use the address as a billing address.</summary>
    public static readonly StripeAddressMode Billing = new("billing");
}