using Soenneker.Gen.EnumValues;

namespace Soenneker.Blazor.Stripe.Elements.Enums;

/// <summary>
/// Toggles the developer assistant sandbox UI when using Elements with Checkout.
/// </summary>
[EnumValue<string>]
public partial class StripeDeveloperAssistantEnabled
{
    // Prevent JSON source generation from assuming an implicit public constructor.
    private StripeDeveloperAssistantEnabled() => throw new System.NotSupportedException("Use a declared enum value.");

    /// <summary>Enable the sandbox assistant UI.</summary>
    public static readonly StripeDeveloperAssistantEnabled True = new("true");

    /// <summary>Disable the sandbox assistant UI.</summary>
    public static readonly StripeDeveloperAssistantEnabled False = new("false");
}
