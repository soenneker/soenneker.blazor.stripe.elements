using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Address;

/// <summary>
/// Custom validation settings for Address Element fields.
/// </summary>
public class StripeAddressValidation
{
    /// <summary>
    /// Validation settings for the phone field.
    /// </summary>
    [JsonPropertyName("phone")]
    public StripePhoneValidation? Phone { get; set; }
}