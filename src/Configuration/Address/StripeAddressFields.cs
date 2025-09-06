using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Address;

/// <summary>
/// Controls which optional fields are included in the Address Element.
/// </summary>
public class StripeAddressFields
{
    /// <summary>
    /// Controls the phone field: 'always', 'auto', or 'never'.
    /// </summary>
    [JsonPropertyName("phone")]
    public Enums.StripeAddressFieldsPhoneOption Phone { get; set; } = Enums.StripeAddressFieldsPhoneOption.Auto;
}
