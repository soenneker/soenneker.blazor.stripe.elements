using Soenneker.Blazor.Stripe.Elements.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Soenneker.Blazor.Stripe.Elements.Configuration;

public sealed class StripeElementsConfiguration
{
    [JsonPropertyName("customerName")]
    public string? CustomerName { get; set; }

    [JsonPropertyName("customerEmail")]
    public string? CustomerEmail { get; set; }

    [JsonPropertyName("publishableKey")]
    public string PublishableKey { get; set; } = null!;

    [JsonPropertyName("stripeConfiguration")]
    public StripeJsConfiguration StripeJsConfiguration { get; set; } = null!;

    [JsonPropertyName("linkAuthenticationElementId")]
    public string? LinkAuthenticationElementId { get; set; }

    [JsonPropertyName("paymentElementId")]
    public string? PaymentElementId { get; set; }

    [JsonPropertyName("addressElementId")]
    public string? AddressElementId { get; set; }

    [JsonPropertyName("addressDefaultValues")]
    public StripeAddressDefaultValues? AddressDefaultValues { get; set; }

    [JsonPropertyName("addressAllowedCountries")]
    public List<string>? AddressAllowedCountries { get; set; }

    [JsonPropertyName("addressBlockPoBox")]
    public bool? AddressBlockPoBox { get; set; }

    [JsonPropertyName("addressAutocompleteApiKey")]
    public string? AddressAutocompleteApiKey { get; set; }

    [JsonPropertyName("addressFieldsPhone")]
    public StripeAddressFieldsPhoneOption? AddressFieldsPhone { get; set; }

    [JsonPropertyName("addressMode")]
    public StripeAddressMode? AddressMode { get; set; }
}