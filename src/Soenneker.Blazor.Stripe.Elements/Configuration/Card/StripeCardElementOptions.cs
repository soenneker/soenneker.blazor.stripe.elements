using System.Text.Json.Serialization;
using Soenneker.Blazor.Stripe.Elements.Enums;

namespace Soenneker.Blazor.Stripe.Elements.Configuration.Card;

/// <summary>
/// Configuration options for Stripe's single-line Card Element.
/// Link autofill is enabled by Stripe when the account and browser are eligible unless <see cref="DisableLink"/> is set.
/// </summary>
public sealed class StripeCardElementOptions
{
    /// <summary>
    /// CSS-like styling rules for the Card Element.
    /// </summary>
    [JsonPropertyName("style")]
    public StripeElementStyle? Style { get; set; }

    /// <summary>
    /// CSS class names applied to the Card Element container for each state.
    /// </summary>
    [JsonPropertyName("classes")]
    public StripeCardElementClasses? Classes { get; set; }

    /// <summary>
    /// Initial values for the Card Element. Stripe only supports prefilling the postal code.
    /// </summary>
    [JsonPropertyName("value")]
    public StripeCardElementDefaultValues? DefaultValues { get; set; }

    /// <summary>
    /// Hides the postal code field when <see langword="true"/>.
    /// </summary>
    [JsonPropertyName("hidePostalCode")]
    public bool? HidePostalCode { get; set; }

    /// <summary>
    /// The card icon style. Supported Stripe values are <c>default</c> and <c>solid</c>.
    /// </summary>
    [JsonPropertyName("iconStyle")]
    public StripeCardElementIconStyle? IconStyle { get; set; }

    /// <summary>
    /// Hides the card brand icon when <see langword="true"/>.
    /// </summary>
    [JsonPropertyName("hideIcon")]
    public bool? HideIcon { get; set; }

    /// <summary>
    /// Disables user input when <see langword="true"/>.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    /// <summary>
    /// Disables Link autofill in this Card Element. Leave unset or set to <see langword="false"/> to allow Link.
    /// </summary>
    [JsonPropertyName("disableLink")]
    public bool? DisableLink { get; set; }
}
