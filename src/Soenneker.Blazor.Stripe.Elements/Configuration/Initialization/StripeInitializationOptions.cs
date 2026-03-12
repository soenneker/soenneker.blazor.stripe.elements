using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Initialization;

/// <summary>
/// Options passed to <c>Stripe(publishableKey, options)</c> when initializing the Stripe.js instance.
/// </summary>
public sealed class StripeInitializationOptions
{
    /// <summary>
    /// For usage with Stripe Connect. Specifies the connected account ID (e.g., acct_24BFMpJ1svR5A89k).
    /// Enables performing actions on behalf of the connected account.
    /// </summary>
    [JsonPropertyName("stripeAccount")]
    public string? StripeAccount { get; set; }

    /// <summary>
    /// Overrides your account's API version. Only available with Stripe.js v3.
    /// Ignored in newer versions like Stripe.js Acacia.
    /// </summary>
    [JsonPropertyName("apiVersion")]
    public string? ApiVersion { get; set; }

    /// <summary>
    /// Locale used for localizing all Stripe.js error messages and Elements.
    /// Default is 'auto', which uses the browser's locale.
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    /// <summary>
    /// Developer tools options for Stripe.js sandbox/testing environments.
    /// </summary>
    [JsonPropertyName("developerTools")]
    public StripeDeveloperToolsOptions? DeveloperTools { get; set; }
}
