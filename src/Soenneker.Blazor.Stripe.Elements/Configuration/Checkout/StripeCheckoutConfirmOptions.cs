using System.Text.Json.Serialization;
using Soenneker.Blazor.Stripe.Elements.Configuration.Address;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Checkout;

/// <summary>
/// Options passed to Checkout Sessions <c>actions.confirm</c>.
/// </summary>
public sealed class StripeCheckoutConfirmOptions
{
    /// <summary>
    /// The URL to return to after any required redirect-based authentication.
    /// </summary>
    [JsonPropertyName("returnUrl")]
    public string? ReturnUrl { get; set; }

    /// <summary>
    /// Stripe redirect behavior. Defaults to <c>if_required</c> in JavaScript interop.
    /// </summary>
    [JsonPropertyName("redirect")]
    public string? Redirect { get; set; }

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
    /// Billing address details.
    /// </summary>
    [JsonPropertyName("billingAddress")]
    public StripeAddressContact? BillingAddress { get; set; }

    /// <summary>
    /// Shipping address details.
    /// </summary>
    [JsonPropertyName("shippingAddress")]
    public StripeAddressContact? ShippingAddress { get; set; }

    /// <summary>
    /// Saved payment method identifier to confirm with, if applicable.
    /// </summary>
    [JsonPropertyName("paymentMethod")]
    public string? PaymentMethod { get; set; }

    /// <summary>
    /// Whether Checkout should save the selected payment method when supported.
    /// </summary>
    [JsonPropertyName("savePaymentMethod")]
    public bool? SavePaymentMethod { get; set; }
}
