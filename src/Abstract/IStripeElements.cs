using Microsoft.AspNetCore.Components;
using Soenneker.Blazor.Stripe.Elements.Configuration;
using Soenneker.Blazor.Stripe.Elements.Dtos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Quark.Components.Cancellable.Abstract;

namespace Soenneker.Blazor.Stripe.Elements.Abstract;

/// <summary>
/// A Blazor component interface for interacting with Stripe Elements.
/// </summary>
public interface IStripeElements : ICancellableElement
{
    /// <summary>
    /// Gets the unique DOM element ID used for the root Stripe Elements container.
    /// </summary>
    string ElementId { get; }

    /// <summary>
    /// Whether to manually initialize the Stripe Elements component.
    /// </summary>
    bool ManuallyInitialize { get; set; }

    /// <summary>
    /// An event callback that is invoked when Stripe Elements has been fully initialized.
    /// </summary>
    EventCallback OnInitialize { get; set; }

    /// <summary>
    /// An event callback that is invoked after the Stripe Elements component has been rendered in the DOM.
    /// Useful for detecting conditional rendering and lazy initialization.
    /// </summary>
    EventCallback OnElementRendered { get; set; }

    /// <summary>
    /// Invoked specifically when the Payment Element iframe has finished rendering and is interactive.
    /// This corresponds to the Stripe 'ready' event for the Payment Element.
    /// </summary>
    EventCallback OnPaymentElementReady { get; set; }

    /// <summary>
    /// Invoked specifically when the Address Element iframe has finished rendering and is interactive.
    /// This corresponds to the Stripe 'ready' event for the Address Element.
    /// </summary>
    EventCallback OnAddressElementReady { get; set; }

    /// <summary>
    /// Invoked specifically when the Link Authentication Element iframe has finished rendering and is interactive.
    /// This corresponds to the Stripe 'ready' event for the LinkAuthentication Element.
    /// </summary>
    EventCallback OnLinkAuthenticationElementReady { get; set; }

    /// <summary>
    /// Invoked after the Submit operation completes, regardless of success or failure.
    /// </summary>
    EventCallback<StripeSubmitResult?> OnAfterSubmit { get; set; }

    /// <summary>
    /// Invoked after the ConfirmPayment operation completes, regardless of success or failure.
    /// </summary>
    EventCallback<StripeConfirmResult?> OnAfterConfirmPayment { get; set; }

    /// <summary>
    /// Invoked after the ConfirmSetup operation completes, regardless of success or failure.
    /// </summary>
    EventCallback<StripeConfirmResult?> OnAfterConfirmSetup { get; set; }

    /// <summary>
    /// Initializes the Stripe Elements component with the specified configuration.
    /// </summary>
    /// <param name="configuration">The Stripe Elements configuration to apply.</param>
    /// <param name="cancellationToken">A token to cancel the initialization operation.</param>
    ValueTask Initialize(StripeElementsConfiguration? configuration = null, CancellationToken cancellationToken = default);

    ValueTask LoadStripe(CancellationToken cancellationToken = default);

    /// <summary>
    /// Confirms a PaymentIntent using the mounted Stripe Elements group.
    /// Uses the configured client secret if not explicitly provided.
    /// </summary>
    /// <param name="returnUrl">The return URL to redirect to after confirmation.</param>
    /// <param name="paymentIntentClientSecret">Optional: The client secret for the PaymentIntent.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    ValueTask<StripeConfirmResult?> ConfirmPayment(string returnUrl, string? paymentIntentClientSecret = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Submits the Stripe Elements group, triggering client-side validation and preparing for confirmation.
    /// This is required for deferred flows and must be called before <c>ConfirmSetup</c> or <c>ConfirmPayment</c>.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A result object containing a possible validation error.</returns>
    ValueTask<StripeSubmitResult?> Submit(CancellationToken cancellationToken = default);

    /// <summary>
    /// Confirms a SetupIntent using the mounted Stripe Elements group.
    /// Uses the configured client secret if not explicitly provided.
    /// </summary>
    /// <param name="returnUrl">The return URL to redirect to after confirmation.</param>
    /// <param name="setupIntentClientSecret">Optional: The client secret for the SetupIntent.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    ValueTask<StripeConfirmResult?> ConfirmSetup(string returnUrl, string? setupIntentClientSecret = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Calls update() on all mounted Stripe elements in the group, typically used after DOM becomes visible (e.g. in tabs or modals).
    /// </summary>
    ValueTask Update(CancellationToken cancellationToken = default);

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
