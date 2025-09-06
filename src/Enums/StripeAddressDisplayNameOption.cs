using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// How to display name fields in the Address Element.
/// </summary>
[Intellenum<string>]
public partial class StripeAddressDisplayNameOption
{
    /// <summary>Display a single full name field.</summary>
    public static readonly StripeAddressDisplayNameOption Full = new("full");

    /// <summary>Display separate first and last name fields.</summary>
    public static readonly StripeAddressDisplayNameOption Split = new("split");

    /// <summary>Display an organization name field.</summary>
    public static readonly StripeAddressDisplayNameOption Organization = new("organization");
}
