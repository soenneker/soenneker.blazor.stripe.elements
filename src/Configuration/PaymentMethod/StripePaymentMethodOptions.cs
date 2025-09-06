using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.PaymentMethod;

/// <summary>
/// Payment method-specific options used with the Payment Element or Express Checkout when initialized without an intent.
/// </summary>
public sealed class StripePaymentMethodOptions
{
    /// <summary>
    /// Options specific to card payment methods.
    /// </summary>
    [JsonPropertyName("card")]
    public StripeCardPaymentOptions? Card { get; set; }

    /// <summary>
    /// Options specific to US bank account payment methods.
    /// </summary>
    [JsonPropertyName("us_bank_account")]
    public StripeUsBankAccountOptions? UsBankAccount { get; set; }
}
