using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.PaymentMethod;

/// <summary>
/// Additional configuration for Financial Connections session creation.
/// </summary>
public sealed class StripeFinancialConnectionsOptions
{
    /// <summary>
    /// Permissions to request. Must include "payment_method" if passed.
    /// </summary>
    [JsonPropertyName("permissions")]
    public List<string>? Permissions { get; set; }

    /// <summary>
    /// Permissions to retrieve during creation. Includes balances, ownership, and transactions.
    /// </summary>
    [JsonPropertyName("prefetch")]
    public List<string>? Prefetch { get; set; }
}