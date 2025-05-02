using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Initialization;

/// <summary>
/// Configuration for Stripe developer tooling when using sandbox/Elements with Checkout Sessions.
/// </summary>
public sealed class StripeDeveloperToolsOptions
{
    /// <summary>
    /// Configuration for the Elements sandbox assistant (if applicable).
    /// </summary>
    [JsonPropertyName("assistant")]
    public StripeDeveloperAssistantOptions? Assistant { get; set; }
}