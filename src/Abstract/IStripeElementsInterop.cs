using Microsoft.JSInterop;
using System;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Blazor.Stripe.Elements.Configuration;

namespace Soenneker.Blazor.Stripe.Elements.Abstract;

/// <summary>
/// A Blazor interop abstraction for integrating with Stripe Elements via JavaScript.
/// </summary>
public interface IStripeElementsInterop : IAsyncDisposable
{
    /// <summary>
    /// Loads the core Stripe.js script asynchronously if it hasn't already been loaded.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    ValueTask LoadStripe(CancellationToken cancellationToken = default);

    /// <summary>
    /// Initializes the Stripe Elements interop by ensuring the Stripe.js script is loaded and the interop module is available.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the initialization operation.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    ValueTask Initialize(CancellationToken cancellationToken = default);

    /// <summary>
    /// Initializes and mounts Stripe Elements components using the specified configuration.
    /// </summary>
    /// <param name="elementId">The unique DOM element ID for the component group.</param>
    /// <param name="dotNetObjectRef">A reference to the Blazor component that will receive callbacks.</param>
    /// <param name="elementsConfiguration">The configuration object containing Stripe setup parameters.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    ValueTask Create(string elementId, DotNetObjectReference<StripeElements> dotNetObjectRef,
        StripeElementsConfiguration elementsConfiguration, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a MutationObserver for the specified DOM element to handle lifecycle and cleanup.
    /// </summary>
    /// <param name="elementId">The unique identifier of the DOM element to observe.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    ValueTask CreateObserver(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Submits and validates the mounted Stripe payment element before attempting confirmation.
    /// </summary>
    /// <param name="elementId">The unique DOM element ID of the Stripe Elements group.</param>
    /// <param name="dotNetObjectRef">A reference to the Blazor component to receive error callbacks.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous validation process.</returns>
    ValueTask ValidatePayment(string elementId, DotNetObjectReference<StripeElements> dotNetObjectRef, CancellationToken cancellationToken = default);

    /// <summary>
    /// Confirms a Stripe PaymentIntent using the mounted Stripe payment element.
    /// </summary>
    /// <param name="elementId">The unique DOM element ID of the Stripe Elements group.</param>
    /// <param name="paymentIntentClientSecret">The client secret for the PaymentIntent.</param>
    /// <param name="returnUrl">The URL to return to after the payment confirmation process completes.</param>
    /// <param name="dotNetObjectRef">A reference to the Blazor component to receive error callbacks.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous confirmation process.</returns>
    ValueTask ConfirmPayment(string elementId, string paymentIntentClientSecret, string returnUrl,
        DotNetObjectReference<StripeElements> dotNetObjectRef, CancellationToken cancellationToken = default);

    /// <summary>
    /// Confirms a Stripe SetupIntent using the mounted Stripe payment element.
    /// </summary>
    /// <param name="elementId">The unique DOM element ID of the Stripe Elements group.</param>
    /// <param name="setupIntentClientSecret">The client secret for the SetupIntent.</param>
    /// <param name="returnUrl">The URL to return to after the setup confirmation process completes.</param>
    /// <param name="dotNetObjectRef">A reference to the Blazor component to receive error callbacks.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous setup confirmation process.</returns>
    ValueTask ConfirmSetup(string elementId, string setupIntentClientSecret, string returnUrl,
        DotNetObjectReference<StripeElements> dotNetObjectRef, CancellationToken cancellationToken = default);

    /// <summary>
    /// Unmounts and cleans up the Stripe Elements instance for the specified element group.
    /// </summary>
    /// <param name="elementId">The unique DOM element ID for the Stripe Elements group.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    ValueTask Unmount(string elementId, CancellationToken cancellationToken = default);
}
