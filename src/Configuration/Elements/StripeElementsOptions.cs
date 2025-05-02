using Soenneker.Blazor.Stripe.Elements.Configuration.Appearance;
using Soenneker.Blazor.Stripe.Elements.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Soenneker.Enums.CurrencyCodes;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Elements;

/// <summary>
/// A set of options to initialize a Stripe Elements instance via <c>stripe.elements(options)</c>.
/// </summary>
public sealed class StripeElementsOptions
{
    /// <summary>
    /// An array of custom fonts (CSS or web fonts) that all created Elements can use.
    /// Fonts can be specified as CSS font sources or custom font objects.
    /// </summary>
    [JsonPropertyName("fonts")]
    public List<StripeFontSource>? Fonts { get; set; }

    /// <summary>
    /// A locale code (e.g., 'en', 'fr') to localize placeholders and error strings.
    /// Defaults to 'auto', where Stripe detects the browser locale.
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    /// <summary>
    /// The mode of the Elements instance. Required when using the Payment Element without an Intent.
    /// Valid values: 'payment', 'setup', or 'subscription'.
    /// </summary>
    [JsonPropertyName("mode")]
    public StripeElementsMode? Mode { get; set; }

    /// <summary>
    /// The currency code (e.g., 'usd'). Required when using the Payment Element without an Intent.
    /// </summary>
    [JsonPropertyName("currency")]
    public CurrencyCode? Currency { get; set; }

    /// <summary>
    /// The amount in the smallest currency unit (e.g., cents for USD).
    /// Required if mode is 'payment' or 'subscription'.
    /// </summary>
    [JsonPropertyName("amount")]
    public long? Amount { get; set; }

    /// <summary>
    /// Indicates whether you intend to make future payments with this method.
    /// Valid values: 'on_session', 'off_session'.
    /// </summary>
    [JsonPropertyName("setupFutureUsage")]
    public StripeElementsSetupFutureUsage? SetupFutureUsage { get; set; }

    /// <summary>
    /// Determines the capture method for the payment: 'automatic', 'automatic_async', or 'manual'.
    /// </summary>
    [JsonPropertyName("captureMethod")]
    public StripeElementsCaptureMethod CaptureMethod { get; set; } = StripeElementsCaptureMethod.Automatic;

    /// <summary>
    /// The Stripe account ID the payment is made on behalf of (Connect only).
    /// </summary>
    [JsonPropertyName("onBehalfOf")]
    public string? OnBehalfOf { get; set; }

    /// <summary>
    /// The list of payment method types to show (e.g., ['card', 'paypal']).
    /// If omitted, it uses the default methods from your Stripe Dashboard.
    /// </summary>
    [JsonPropertyName("paymentMethodTypes")]
    public List<string>? PaymentMethodTypes { get; set; }

    /// <summary>
    /// Payment method configuration ID from Stripe Dashboard (if managing there).
    /// </summary>
    [JsonPropertyName("paymentMethodConfiguration")]
    public string? PaymentMethodConfiguration { get; set; }

    /// <summary>
    /// Additional configuration for payment-method-specific behavior when no Intent is used.
    /// </summary>
    [JsonPropertyName("paymentMethodOptions")]
    public StripeCustomPaymentMethodOptions? PaymentMethodOptions { get; set; }

    /// <summary>
    /// Appearance configuration that customizes the style of Elements.
    /// Accepts a complex object of style rules (colors, fonts, spacing, etc.).
    /// </summary>
    [JsonPropertyName("appearance")]
    public StripeAppearance? Appearance { get; set; }

    /// <summary>
    /// Controls whether and when to display a skeleton loading UI.
    /// Valid values: 'auto', 'always', 'never'. Default is 'auto'.
    /// </summary>
    [JsonPropertyName("loader")]
    public StripeElementsLoader Loader { get; set; } = StripeElementsLoader.Auto;

    /// <summary>
    /// The client secret for a PaymentIntent or SetupIntent (when used with Intents).
    /// </summary>
    [JsonPropertyName("clientSecret")]
    public string? ClientSecret { get; set; }

    /// <summary>
    /// A client secret returned from creating a CustomerSession.
    /// Used with Payment and Address Elements.
    /// </summary>
    [JsonPropertyName("customerSessionClientSecret")]
    public string? CustomerSessionClientSecret { get; set; }

    /// <summary>
    /// Controls display of a sync-address checkbox when using both billing and shipping Address Elements.
    /// Values: 'billing', 'shipping', or 'none'. Default is 'billing'.
    /// </summary>
    [JsonPropertyName("syncAddressCheckbox")]
    public StripeSyncAddressCheckboxOption? SyncAddressCheckbox { get; set; }

    /// <summary>
    /// Allows PaymentMethods to be created manually via <c>stripe.createPaymentMethod</c>.
    /// </summary>
    [JsonPropertyName("paymentMethodCreation")]
    public string? PaymentMethodCreation { get; set; }

    /// <summary>
    /// A list of custom payment methods registered in the Stripe Dashboard to be shown in the Payment Element.
    /// </summary>
    [JsonPropertyName("customPaymentMethods")]
    public List<StripeCustomPaymentMethod>? CustomPaymentMethods { get; set; }
}