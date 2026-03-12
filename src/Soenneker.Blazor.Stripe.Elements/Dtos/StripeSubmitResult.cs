using System.Text.Json.Serialization;
using Soenneker.Dtos.Stripe.Error;

namespace Soenneker.Blazor.Stripe.Elements.Dtos;

public sealed class StripeSubmitResult
{
    [JsonPropertyName("error")]
    public StripeErrorDto? Error { get; set; }
}
