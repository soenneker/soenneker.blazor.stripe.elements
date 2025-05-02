using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Payment;

/// <summary>
/// Configuration options for creating the Stripe Payment Element.
/// </summary>
public sealed class StripePaymentElementOptions
{
    /// <summary>
    /// Layout configuration for the Payment Element. Accepts 'accordion', 'tabs', or a custom layout object.
    /// </summary>
    [JsonPropertyName("layout")]
    public object? Layout { get; set; }

    /// <summary>
    /// Initial customer values such as email, name, phone.
    /// </summary>
    [JsonPropertyName("defaultValues")]
    public StripeDefaultCustomerValues? DefaultValues { get; set; }

    /// <summary>
    /// Business information such as name used for mandate text.
    /// </summary>
    [JsonPropertyName("business")]
    public StripeBusinessInfo? Business { get; set; }

    /// <summary>
    /// Optional explicit ordering of payment methods.
    /// </summary>
    [JsonPropertyName("paymentMethodOrder")]
    public List<string>? PaymentMethodOrder { get; set; }

    /// <summary>
    /// Billing details collection control.
    /// </summary>
    [JsonPropertyName("fields")]
    public StripePaymentFields? Fields { get; set; }

    /// <summary>
    /// Whether the element should be read-only.
    /// </summary>
    [JsonPropertyName("readOnly")]
    public bool? ReadOnly { get; set; }

    /// <summary>
    /// Display settings for mandate and legal agreements.
    /// </summary>
    [JsonPropertyName("terms")]
    public StripeTermsControl? Terms { get; set; }

    /// <summary>
    /// Wallet-specific visibility control (e.g., Apple Pay, Google Pay).
    /// </summary>
    [JsonPropertyName("wallets")]
    public StripeWalletControls? Wallets { get; set; }

    /// <summary>
    /// Apple Pay-specific advanced settings.
    /// </summary>
    [JsonPropertyName("applePay")]
    public StripeApplePayOptions? ApplePay { get; set; }

    /// <summary>
    /// CSS-like styling rules for the Address Element (base, invalid, etc).
    /// </summary>
    [JsonPropertyName("style")]
    public StripeElementStyle? Style { get; set; }
}