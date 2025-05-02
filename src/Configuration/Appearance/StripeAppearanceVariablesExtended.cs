using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Appearance;

/// <summary>
/// Predefined variables used to control base appearance theming.
/// Additional keys are allowed via <see cref="AdditionalVariables"/>.
/// </summary>
public sealed class StripeAppearanceVariablesExtended : StripeAppearanceVariables
{
    /// <summary>
    /// Arbitrary additional variables (e.g., for future Stripe support).
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalVariables { get; set; }
}