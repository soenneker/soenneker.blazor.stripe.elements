using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Soenneker.Blazor.Stripe.Elements.Configuration;
using Soenneker.Blazor.Utils.EventListeningInterop.Abstract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Blazor.Stripe.Elements.Abstract;

/// <summary>
/// A Blazor interop library for Stripe Elements
/// </summary>
public interface IStripeElementsInterop : IEventListeningInterop, IAsyncDisposable
{
    /// <summary>
    /// Initializes the StripeElements interop by loading required scripts and styles.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the initialization operation.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    ValueTask Initialize(CancellationToken cancellationToken = default);

    ValueTask Create(ElementReference elementReference, string elementId, DotNetObjectReference<StripeElements> dotNetObjectRef,
        StripeElementsConfiguration elementsConfiguration, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a MutationObserver for the element with the specified identifier.
    /// </summary>
    /// <param name="elementId">The unique identifier of the target element.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    ValueTask CreateObserver(string elementId, CancellationToken cancellationToken = default);

    ValueTask ValidatePayment(DotNetObjectReference<StripeElements> dotNetObjectRef, CancellationToken cancellationToken = default);

    ValueTask SubmitPayment(string paymentIntent, string returnUrl, DotNetObjectReference<StripeElements> dotNetObjectRef,
        CancellationToken cancellationToken = default);
}