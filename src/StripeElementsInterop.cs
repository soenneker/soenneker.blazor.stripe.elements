using Microsoft.JSInterop;
using Soenneker.Blazor.Stripe.Elements.Abstract;
using Soenneker.Blazor.Utils.ResourceLoader.Abstract;
using Soenneker.Asyncs.Initializers;
using Soenneker.Extensions.CancellationTokens;
using Soenneker.Utils.CancellationScopes;
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
    private readonly AsyncInitializer _stripeJsInitializer;
    private readonly AsyncInitializer _scriptInitializer;

    private readonly IJSRuntime _jsRuntime;

    private const string _module = "Soenneker.Blazor.Stripe.Elements/js/stripeelementsinterop.js";
    private const string _moduleName = "StripeElementsInterop";

    private readonly CancellationScope _cancellationScope = new();

    public StripeElementsInterop(IJSRuntime jSRuntime, IResourceLoader resourceLoader)
    {
        _jsRuntime = jSRuntime;
        _resourceLoader = resourceLoader;
        _stripeJsInitializer = new AsyncInitializer(InitializeStripeJs);
        _scriptInitializer = new AsyncInitializer(InitializeScript);
    }

    private ValueTask InitializeStripeJs(CancellationToken token)
    {
        return _resourceLoader.LoadScript("https://js.stripe.com/v3/", async: true, cancellationToken: token);
    }

    private async ValueTask InitializeScript(CancellationToken token)
    {
        await _resourceLoader.WaitForVariable("Stripe", cancellationToken: token);
        await _resourceLoader.ImportModuleAndWaitUntilAvailable(_module, _moduleName, 100, token);
    }

    public ValueTask LoadStripe(CancellationToken cancellationToken = default)
    {
        var linked = _cancellationScope.CancellationToken.Link(cancellationToken, out var source);

        using (source)
            return _stripeJsInitializer.Init(linked);
    }

    public async ValueTask Initialize(CancellationToken cancellationToken = default)
    {
        var linked = _cancellationScope.CancellationToken.Link(cancellationToken, out var source);

        using (source)
        {
            await _stripeJsInitializer.Init(linked);
            await _scriptInitializer.Init(linked);
        }
    }

    public ValueTask CreateObserver(string elementId, CancellationToken cancellationToken = default)
    {
        var linked = _cancellationScope.CancellationToken.Link(cancellationToken, out var source);

        using (source)
            return _jsRuntime.InvokeVoidAsync("StripeElementsInterop.createObserver", linked, elementId);
    }

    public async ValueTask Create(string elementId, DotNetObjectReference<StripeElements> dotNetObjectRef, StripeElementsConfiguration elementsConfiguration,
        CancellationToken cancellationToken = default)
    {
        var linked = _cancellationScope.CancellationToken.Link(cancellationToken, out var source);

        using (source)
        {
            await _scriptInitializer.Init(linked);
            string? json = JsonUtil.Serialize(elementsConfiguration);
            await _jsRuntime.InvokeVoidAsync("StripeElementsInterop.create", linked, elementId, json, dotNetObjectRef);
        }
    }

    public ValueTask<StripeConfirmResult?> ConfirmPayment(string elementId, string paymentIntentClientSecret, string returnUrl,
        CancellationToken cancellationToken = default)
    {
        var linked = _cancellationScope.CancellationToken.Link(cancellationToken, out var source);

        using (source)
            return _jsRuntime.InvokeAsync<StripeConfirmResult?>("StripeElementsInterop.confirmPayment", linked, elementId, paymentIntentClientSecret,
            returnUrl);
    }

    public ValueTask<StripeSubmitResult?> Submit(string elementId, CancellationToken cancellationToken = default)
    {
        var linked = _cancellationScope.CancellationToken.Link(cancellationToken, out var source);

        using (source)
            return _jsRuntime.InvokeAsync<StripeSubmitResult?>("StripeElementsInterop.submit", linked, elementId);
    }

    public ValueTask<StripeConfirmResult?> ConfirmSetup(string elementId, string setupIntentClientSecret, string returnUrl,
        CancellationToken cancellationToken = default)
    {
        var linked = _cancellationScope.CancellationToken.Link(cancellationToken, out var source);

        using (source)
            return _jsRuntime.InvokeAsync<StripeConfirmResult?>("StripeElementsInterop.confirmSetup", linked, elementId, setupIntentClientSecret,
            returnUrl);
    }

    public ValueTask Update(string elementId, CancellationToken cancellationToken = default)
    {
        var linked = _cancellationScope.CancellationToken.Link(cancellationToken, out var source);

        using (source)
            return _jsRuntime.InvokeVoidAsync("StripeElementsInterop.update", linked, elementId);
    }

    public ValueTask Unmount(string elementId, CancellationToken cancellationToken = default)
    {
        var linked = _cancellationScope.CancellationToken.Link(cancellationToken, out var source);

        using (source)
            return _jsRuntime.InvokeVoidAsync("StripeElementsInterop.unmountGroup", linked, elementId);
    }

    public async ValueTask DisposeAsync()
    {
        await _resourceLoader.DisposeModule(_module);
        await _scriptInitializer.DisposeAsync();
        await _cancellationScope.DisposeAsync();
    }
}