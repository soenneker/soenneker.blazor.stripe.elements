using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Controls visibility of wallet payment options (Apple Pay, Google Pay, etc.).
/// </summary>
[Intellenum<string>]
public partial class StripeWalletDisplayOption
{
    /// <summary>Show wallet options if available.</summary>
    public static readonly StripeWalletDisplayOption Auto = new("auto");

    /// <summary>Never show wallet options.</summary>
    public static readonly StripeWalletDisplayOption Never = new("never");
}
