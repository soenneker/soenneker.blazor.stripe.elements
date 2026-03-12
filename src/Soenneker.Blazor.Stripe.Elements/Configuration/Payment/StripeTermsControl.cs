using Soenneker.Blazor.Stripe.Elements.Enums;
using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Payment;

/// <summary>
/// Controls the display behavior of legal terms and mandate text for each supported payment method in the Payment Element.
/// </summary>
public class StripeTermsControl
{
    /// <summary>
    /// Controls display of terms for Apple Pay.
    /// </summary>
    [JsonPropertyName("applePay")]
    public StripeTermsDisplayOption? ApplePay { get; set; }

    /// <summary>
    /// Controls display of terms for AU BECS Debit (Australia direct debit).
    /// </summary>
    [JsonPropertyName("auBecsDebit")]
    public StripeTermsDisplayOption? AuBecsDebit { get; set; }

    /// <summary>
    /// Controls display of terms for Bancontact.
    /// </summary>
    [JsonPropertyName("bancontact")]
    public StripeTermsDisplayOption? Bancontact { get; set; }

    /// <summary>
    /// Controls display of terms for card-based payments.
    /// </summary>
    [JsonPropertyName("card")]
    public StripeTermsDisplayOption? Card { get; set; }

    /// <summary>
    /// Controls display of terms for Cash App Pay.
    /// </summary>
    [JsonPropertyName("cashapp")]
    public StripeTermsDisplayOption? CashApp { get; set; }

    /// <summary>
    /// Controls display of terms for Google Pay.
    /// </summary>
    [JsonPropertyName("googlePay")]
    public StripeTermsDisplayOption? GooglePay { get; set; }

    /// <summary>
    /// Controls display of terms for iDEAL (Netherlands).
    /// </summary>
    [JsonPropertyName("ideal")]
    public StripeTermsDisplayOption? Ideal { get; set; }

    /// <summary>
    /// Controls display of terms for PayPal.
    /// </summary>
    [JsonPropertyName("paypal")]
    public StripeTermsDisplayOption? Paypal { get; set; }

    /// <summary>
    /// Controls display of terms for SEPA Direct Debit.
    /// </summary>
    [JsonPropertyName("sepaDebit")]
    public StripeTermsDisplayOption? SepaDebit { get; set; }

    /// <summary>
    /// Controls display of terms for SOFORT (EU bank transfer).
    /// </summary>
    [JsonPropertyName("sofort")]
    public StripeTermsDisplayOption? Sofort { get; set; }

    /// <summary>
    /// Controls display of terms for US bank account payments.
    /// </summary>
    [JsonPropertyName("usBankAccount")]
    public StripeTermsDisplayOption? UsBankAccount { get; set; }
}
