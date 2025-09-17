using Microsoft.JSInterop;
using Soenneker.Blazor.Stripe.Elements.Abstract;
using Soenneker.Blazor.Utils.ResourceLoader.Abstract;
using Soenneker.Utils.AsyncSingleton;
using Soenneker.Utils.Json;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Blazor.Stripe.Elements.Configuration;
using Soenneker.Blazor.Stripe.Elements.Dtos;

namespace Soenneker.Blazor.Stripe.Elements;

/// <inheritdoc cref="IStripeElementsInterop"/>
public sealed class StripeElementsInterop : IStripeElementsInterop
{
    private readonly IResourceLoader _resourceLoader;
    private readonly AsyncSingleton _stripeJsInitializer;
    private readonly AsyncSingleton _scriptInitializer;

    private readonly IJSRuntime _jsRuntime;

    private const string _module = "Soenneker.Blazor.Stripe.Elements/js/stripeelementsinterop.js";
    private const string _moduleName = "StripeElementsInterop";

    public StripeElementsInterop(IJSRuntime jSRuntime, IResourceLoader resourceLoader)
    {
        _jsRuntime = jSRuntime;
        _resourceLoader = resourceLoader;

        _stripeJsInitializer = new AsyncSingleton(async (token, _) =>
        {
            await _resourceLoader.LoadScript("https://js.stripe.com/v3/", async: true, cancellationToken: token);
            return new object();
        });

        _scriptInitializer = new AsyncSingleton(async (token, _) =>
        {
            await _resourceLoader.WaitForVariable("Stripe", cancellationToken: token);
            await _resourceLoader.ImportModuleAndWaitUntilAvailable(_module, _moduleName, 100, token);
            return new object();
        });
    }

    public ValueTask LoadStripe(CancellationToken cancellationToken = default)
    {
        return _stripeJsInitializer.Init(cancellationToken);
    }

    public async ValueTask Initialize(CancellationToken cancellationToken = default)
    {
        await _stripeJsInitializer.Init(cancellationToken);
        await _scriptInitializer.Init(cancellationToken);
    }

    public ValueTask CreateObserver(string elementId, CancellationToken cancellationToken = default)
    {
        return _jsRuntime.InvokeVoidAsync($"{_moduleName}.createObserver", cancellationToken, elementId);
    }

    public async ValueTask Create(string elementId, DotNetObjectReference<StripeElements> dotNetObjectRef, StripeElementsConfiguration elementsConfiguration,
        CancellationToken cancellationToken = default)
    {
        await _scriptInitializer.Init(cancellationToken);
        string? json = JsonUtil.Serialize(elementsConfiguration);
        await _jsRuntime.InvokeVoidAsync($"{_moduleName}.create", cancellationToken, elementId, json, dotNetObjectRef);
    }

    public ValueTask<StripeConfirmResult?> ConfirmPayment(string elementId, string paymentIntentClientSecret, string returnUrl,
        CancellationToken cancellationToken = default)
    {
        return _jsRuntime.InvokeAsync<StripeConfirmResult?>($"{_moduleName}.confirmPayment", cancellationToken, elementId, paymentIntentClientSecret,
            returnUrl);
    }

    public ValueTask<StripeSubmitResult?> Submit(string elementId, CancellationToken cancellationToken = default)
    {
        return _jsRuntime.InvokeAsync<StripeSubmitResult?>($"{_moduleName}.submit", cancellationToken, elementId);
    }

    public ValueTask<StripeConfirmResult?> ConfirmSetup(string elementId, string setupIntentClientSecret, string returnUrl,
        CancellationToken cancellationToken = default)
    {
        return _jsRuntime.InvokeAsync<StripeConfirmResult?>($"{_moduleName}.confirmSetup", cancellationToken, elementId, setupIntentClientSecret, returnUrl);
    }

    public ValueTask Update(string elementId, CancellationToken cancellationToken = default)
    {
        return _jsRuntime.InvokeVoidAsync($"{_moduleName}.update", cancellationToken, elementId);
    }

    public ValueTask Unmount(string elementId, CancellationToken cancellationToken = default)
    {
        return _jsRuntime.InvokeVoidAsync($"{_moduleName}.unmountGroup", cancellationToken, elementId);
    }

    public async ValueTask DisposeAsync()
    {
        await _resourceLoader.DisposeModule(_module);
        await _scriptInitializer.DisposeAsync();
    }
}
