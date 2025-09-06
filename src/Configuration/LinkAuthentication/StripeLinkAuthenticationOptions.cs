using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.LinkAuthentication;

/// <summary>
/// Configuration options for creating the Link Authentication Element.
/// </summary>
public sealed class StripeLinkAuthenticationOptions
{
    /// <summary>
    /// Default contact information to prepopulate the Link Authentication Element.
    /// </summary>
    [JsonPropertyName("defaultValues")]
    public StripeLinkAuthenticationDefaultValues? DefaultValues { get; set; }
}
