using Soenneker.Blazor.Stripe.Elements.Enums;
using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Payment;

/// <summary>
/// Controls which digital wallets are shown in the Payment Element.
/// </summary>
public class StripeWalletControls
{
    [JsonPropertyName("applePay")]
    public StripeWalletDisplayOption? ApplePay { get; set; }

    [JsonPropertyName("googlePay")]
    public StripeWalletDisplayOption? GooglePay { get; set; }

    [JsonPropertyName("link")]
    public StripeWalletDisplayOption? Link { get; set; }
}