using Soenneker.Blazor.Stripe.Elements.Enums;
using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Address;

/// <summary>
/// Validation rules for the phone field.
/// </summary>
public class StripePhoneValidation
{
    /// <summary>
    /// Required mode: 'always', 'auto', or 'never'.
    /// </summary>
    [JsonPropertyName("required")]
    public StripeAddressValidationPhoneRequired Required { get; set; } = StripeAddressValidationPhoneRequired.Auto;
}