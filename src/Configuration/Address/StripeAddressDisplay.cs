using Soenneker.Blazor.Stripe.Elements.Enums;
using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Address;

/// <summary>
/// Controls display mode of name fields.
/// </summary>
public class StripeAddressDisplay
{
    /// <summary>
    /// 'full', 'split', or 'organization'.
    /// </summary>
    [JsonPropertyName("name")]
    public StripeAddressDisplayNameOption Name { get; set; } = StripeAddressDisplayNameOption.Full;
}