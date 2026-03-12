using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Payment;

/// <summary>
/// Defines billing details for the Payment Element, including name, email, phone, and address.
/// </summary>
public sealed class StripePaymentElementBillingDetails
{
    /// <summary>
    /// Full name or organization name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Email address. May be prefilled based on customer context.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Phone number.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Billing address details.
    /// </summary>
    [JsonPropertyName("address")]
    public StripeAddressDetails? Address { get; set; }
}
