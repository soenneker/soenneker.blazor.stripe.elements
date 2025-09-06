using System.Text.Json.Serialization;
using Soenneker.Dtos.Stripe.Error;

namespace Soenneker.Blazor.Stripe.Elements.Dtos;

/// <summary>
/// Represents the result returned from a call to Stripe's <c>confirmSetup</c> or <c>confirmPayment</c> function.
/// </summary>
public sealed class StripeConfirmResult
{
    /// <summary>
    /// An error returned by Stripe, if any occurred during confirmation.
    /// </summary>
    [JsonPropertyName("error")]
    public StripeErrorDto? Error { get; set; }

    /// <summary>
    /// The full SetupIntent object returned from Stripe on setup confirmation.
    /// </summary>
    [JsonPropertyName("setupIntent")]
    public StripeIntent? SetupIntent { get; set; }

    /// <summary>
    /// The full PaymentIntent object returned from Stripe on payment confirmation.
    /// </summary>
    [JsonPropertyName("paymentIntent")]
    public StripeIntent? PaymentIntent { get; set; }
}
