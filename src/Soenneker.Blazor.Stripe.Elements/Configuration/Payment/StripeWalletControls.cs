using Soenneker.Blazor.Stripe.Elements.Enums;
using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Payment;

/// <summary>
/// Controls which digital wallets are shown in the Payment Element.
/// </summary>
public class StripeWalletControls
{
    /// <summary>
    /// Gets or sets apple pay.
    /// </summary>
    [JsonPropertyName("applePay")]
    public StripeWalletDisplayOption? ApplePay { get; set; }

    /// <summary>
    /// Gets or sets google pay.
    /// </summary>
    [JsonPropertyName("googlePay")]
    public StripeWalletDisplayOption? GooglePay { get; set; }

    /// <summary>
    /// Gets or sets link.
    /// </summary>
    [JsonPropertyName("link")]
    public StripeWalletDisplayOption? Link { get; set; }
}
