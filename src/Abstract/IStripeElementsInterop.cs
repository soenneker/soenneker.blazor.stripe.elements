using Microsoft.JSInterop;
using Soenneker.Blazor.Stripe.Elements.Configuration;
using Soenneker.Blazor.Stripe.Elements.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Blazor.Stripe.Elements.Abstract;

/// <summary>
/// Provides JavaScript interop methods for managing and interacting with Stripe Elements in a Blazor application.
/// </summary>
public interface IStripeElementsInterop : IAsyncDisposable
{
    /// <summary>
    /// Loads the core Stripe.js library asynchronously, if it has not already been loaded.
    /// </summary>
    /// <param name="cancellationToken">A token that can be used to cancel the loading operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    ValueTask LoadStripe(CancellationToken cancellationToken = default);

    /// <summary>
    /// Initializes the Stripe Elements interop environment by ensuring that Stripe.js is loaded and the interop module is available.
    /// </summary>
    /// <param name="cancellationToken">A token that can be used to cancel the initialization operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    ValueTask Initialize(CancellationToken cancellationToken = default);

    /// <summary>
    /// Initializes and mounts Stripe Elements components using the specified configuration and DOM container ID.
    /// </summary>
    /// <param name="elementId">The DOM element ID for the root Stripe Elements container.</param>
    /// <param name="dotNetObjectRef">A reference to the .NET component to receive JS-invokable callbacks.</param>
    /// <param name="elementsConfiguration">The configuration used to initialize Stripe Elements.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    ValueTask Create(string elementId, DotNetObjectReference<StripeElements> dotNetObjectRef, StripeElementsConfiguration elementsConfiguration, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a MutationObserver for the specified DOM element to automatically clean up mounted elements when removed from the DOM.
    /// </summary>
    /// <param name="elementId">The DOM element ID to observe.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    ValueTask CreateObserver(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Confirms a Stripe PaymentIntent using the mounted Stripe Payment Element and returns the result.
    /// This method uses Stripe.js to handle 3D Secure if required and returns the full result object.
    /// </summary>
    /// <param name="elementId">The DOM element ID of the Stripe Elements group.</param>
    /// <param name="paymentIntentClientSecret">The client secret associated with the PaymentIntent.</param>
    /// <param name="returnUrl">The URL to redirect to after 3D Secure authentication, if required.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the confirmation operation.</param>
    /// <returns>A task representing the asynchronous operation, returning the full Stripe confirmation result.</returns>
    ValueTask<StripeConfirmResult?> ConfirmPayment(string elementId, string paymentIntentClientSecret, string returnUrl, CancellationToken cancellationToken = default);

    /// <summary>
    /// Submits and validates the mounted Stripe Payment Element.
    /// If validation fails, error details will be passed to the specified .NET callback.
    /// </summary>
    /// <param name="elementId">The DOM element ID of the Stripe Elements group.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the validation operation.</param>
    /// <returns>A task representing the asynchronous validation process.</returns>
    ValueTask<StripeSubmitResult?> Submit(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Confirms a Stripe SetupIntent using the mounted Stripe Payment Element and returns the result.
    /// This method uses Stripe.js to handle 3D Secure if required and returns the full result object.
    /// </summary>
    /// <param name="elementId">The DOM element ID of the Stripe Elements group.</param>
    /// <param name="setupIntentClientSecret">The client secret associated with the SetupIntent.</param>
    /// <param name="returnUrl">The URL to redirect to after 3D Secure authentication, if required.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the confirmation operation.</param>
    /// <returns>A task representing the asynchronous operation, returning the full Stripe confirmation result.</returns>
    ValueTask<StripeConfirmResult?> ConfirmSetup(string elementId, string setupIntentClientSecret, string returnUrl, CancellationToken cancellationToken = default);

    ValueTask Update(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Unmounts and destroys all mounted Stripe Elements components within the specified DOM element group.
    /// This also removes any associated observers and resources.
    /// </summary>
    /// <param name="elementId">The DOM element ID for the Stripe Elements group to unmount.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the unmount operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    ValueTask Unmount(string elementId, CancellationToken cancellationToken = default);
}
