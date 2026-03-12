using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Initialization;

/// <summary>
/// Options for controlling the behavior of the Stripe Elements sandbox assistant UI.
/// </summary>
public sealed class StripeDeveloperAssistantOptions
{
    /// <summary>
    /// Whether to enable the sandbox assistant UI. Default is true.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }
}
