using Microsoft.JSInterop;
using Soenneker.Blazor.Stripe.Elements.Abstract;
using Soenneker.Blazor.Stripe.Elements.Configuration;
using Soenneker.Blazor.Utils.EventListeningInterop;
using Soenneker.Blazor.Utils.ResourceLoader.Abstract;
using Soenneker.Extensions.ValueTask;
using Soenneker.Utils.AsyncSingleton;
using Soenneker.Utils.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Soenneker.Blazor.Stripe.Elements;

/// <inheritdoc cref="IStripeElementsInterop"/>
public class StripeElementsInterop : EventListeningInterop, IStripeElementsInterop
{
    private readonly IResourceLoader _resourceLoader;
    private readonly AsyncSingleton _scriptInitializer;

    private const string _module = "Soenneker.Blazor.Stripe.Elements/js/stripeelementsinterop.js";

    public StripeElementsInterop(IJSRuntime jSRuntime, IResourceLoader resourceLoader) : base(jSRuntime)
    {
        _resourceLoader = resourceLoader;

        _scriptInitializer = new AsyncSingleton(async (token, _) =>
        {
            await _resourceLoader.LoadScriptAndWaitForVariable("https://js.stripe.com/v3/", "Stripe", async: true, cancellationToken: token).NoSync();

            await _resourceLoader.ImportModuleAndWaitUntilAvailable(_module, "StripeElementsInterop", 100, token).NoSync();

            return new object();
        });
    }

    public ValueTask Initialize(CancellationToken cancellationToken = default)
    {
        return _scriptInitializer.Init(cancellationToken);
    }

    public ValueTask CreateObserver(string elementId, CancellationToken cancellationToken = default)
    {
        return JsRuntime.InvokeVoidAsync("StripeElementsInterop.createObserver", cancellationToken, elementId);
    }

    public async ValueTask Create(ElementReference elementReference, string elementId, DotNetObjectReference<StripeElements> dotNetObjectRef, StripeElementsConfiguration elementsConfiguration,
        CancellationToken cancellationToken = default)
    {
        await _scriptInitializer.Init(cancellationToken).NoSync();

        string? json = JsonUtil.Serialize(elementsConfiguration);

        await JsRuntime.InvokeVoidAsync("StripeElementsInterop.create", cancellationToken, elementReference, elementId, json, dotNetObjectRef).NoSync();
    }

    public ValueTask ValidatePayment(DotNetObjectReference<StripeElements> dotNetObjectRef, CancellationToken cancellationToken = default)
    {
        return JsRuntime.InvokeVoidAsync("StripeElementsInterop.validatePayment", cancellationToken, dotNetObjectRef);
    }

    public ValueTask SubmitPayment(string paymentIntent, string returnUrl, DotNetObjectReference<StripeElements> dotNetObjectRef,
        CancellationToken cancellationToken = default)
    {
        return JsRuntime.InvokeVoidAsync("StripeElementsInterop.submitPayment", cancellationToken, paymentIntent, returnUrl, dotNetObjectRef);
    }

    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        await _resourceLoader.DisposeModule(_module).NoSync();

        await _scriptInitializer.DisposeAsync().NoSync();
    }
}