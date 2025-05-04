using Soenneker.Blazor.Stripe.Elements.Configuration;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Blazor.Stripe.Elements.Abstract;

/// <summary>
/// A Blazor component interface for interacting with Stripe Elements.
/// </summary>
public interface IStripeElements : IAsyncDisposable
{
    /// <summary>
    /// Gets the unique DOM element ID used for the root Stripe Elements container.
    /// </summary>
    string ElementId { get; }

    /// <summary>
    /// Initializes the Stripe Elements component with the specified configuration.
    /// </summary>
    /// <param name="configuration">The Stripe Elements configuration to apply.</param>
    /// <param name="cancellationToken">A token to cancel the initialization operation.</param>
    ValueTask Initialize(StripeElementsConfiguration? configuration = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Validates the Stripe Elements input fields (used for PaymentIntents only).
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the validation.</param>
    ValueTask ValidatePayment(CancellationToken cancellationToken = default);

    /// <summary>
    /// Confirms a PaymentIntent using the mounted Stripe Elements group.
    /// Uses the configured client secret if not explicitly provided.
    /// </summary>
    /// <param name="returnUrl">The return URL to redirect to after confirmation.</param>
    /// <param name="paymentIntentClientSecret">Optional: The client secret for the PaymentIntent.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    ValueTask ConfirmPayment(string returnUrl, string? paymentIntentClientSecret = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Confirms a SetupIntent using the mounted Stripe Elements group.
    /// Uses the configured client secret if not explicitly provided.
    /// </summary>
    /// <param name="returnUrl">The return URL to redirect to after confirmation.</param>
    /// <param name="setupIntentClientSecret">Optional: The client secret for the SetupIntent.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    ValueTask ConfirmSetup(string returnUrl, string? setupIntentClientSecret = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Unmounts the current Stripe Elements instance and cleans up resources.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the unmount operation.</param>
    ValueTask Unmount(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the generated element IDs for each Stripe element type.
    /// </summary>
    Dictionary<Type, string> ElementIds { get; }

    /// <summary>
    /// Gets or sets the current configuration object used to create Stripe Elements.
    /// </summary>
    StripeElementsConfiguration? Configuration { get; set; }
}
