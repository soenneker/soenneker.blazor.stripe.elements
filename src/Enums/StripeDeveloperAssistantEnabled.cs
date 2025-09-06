using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Toggles the developer assistant sandbox UI when using Elements with Checkout.
/// </summary>
[Intellenum<string>]
public partial class StripeDeveloperAssistantEnabled
{
    /// <summary>Enable the sandbox assistant UI.</summary>
    public static readonly StripeDeveloperAssistantEnabled True = new("true");

    /// <summary>Disable the sandbox assistant UI.</summary>
    public static readonly StripeDeveloperAssistantEnabled False = new("false");
}
