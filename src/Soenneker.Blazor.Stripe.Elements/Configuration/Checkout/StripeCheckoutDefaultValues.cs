using System.Text.Json.Serialization;
using Soenneker.Blazor.Stripe.Elements.Configuration.Address;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Checkout;

/// <summary>
/// Default customer details used when initializing a Checkout Sessions Elements group.
/// </summary>
public sealed class StripeCheckoutDefaultValues
{
    /// <summary>
    /// Customer email address.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Customer phone number.
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Default billing address details.
    /// </summary>
    [JsonPropertyName("billingAddress")]
    public StripeAddressContact? BillingAddress { get; set; }

    /// <summary>
    /// Default shipping address details.
    /// </summary>
    [JsonPropertyName("shippingAddress")]
    public StripeAddressContact? ShippingAddress { get; set; }
}
