using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.LinkAuthentication;

/// <summary>
/// Default values for the Link Authentication Element.
/// </summary>
public sealed class StripeLinkAuthenticationDefaultValues
{
    /// <summary>
    /// The initial email address to display in the authentication form.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }
}
