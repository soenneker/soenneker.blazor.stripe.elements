using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.PaymentMethod;

/// <summary>
/// Configuration for US bank account payment method.
/// </summary>
public sealed class StripeUsBankAccountOptions
{
    /// <summary>
    /// Verification method for the bank account collection flow. Can be 'automatic' or 'instant'.
    /// </summary>
    [JsonPropertyName("verification_method")]
    public string? VerificationMethod { get; set; }

    /// <summary>
    /// Options for Financial Connections integration with the bank account.
    /// </summary>
    [JsonPropertyName("financial_connections")]
    public StripeFinancialConnectionsOptions? FinancialConnections { get; set; }
}
