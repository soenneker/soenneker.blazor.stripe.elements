using Microsoft.JSInterop;
using Soenneker.Blazor.Stripe.Elements.Abstract;
using Soenneker.Blazor.Utils.ModuleImport.Abstract;
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
    private readonly IModuleImportUtil _moduleImportUtil;
    private readonly AsyncInitializer _stripeJsInitializer;
    private readonly AsyncInitializer _scriptInitializer;

    private const string _wrapperModulePath = "_content/Soenneker.Blazor.Stripe.Elements/js/stripeelementsinterop.js";

    private readonly CancellationScope _cancellationScope = new();

    public StripeElementsInterop(IResourceLoader resourceLoader, IModuleImportUtil moduleImportUtil)
    {
        _resourceLoader = resourceLoader;
        _moduleImportUtil = moduleImportUtil;
        _stripeJsInitializer = new AsyncInitializer(InitializeStripeJs);
        _scriptInitializer = new AsyncInitializer(InitializeScript);
    }

    private ValueTask InitializeStripeJs(CancellationToken token)
    {
        return _resourceLoader.LoadScript("https://js.stripe.com/v3/", crossOrigin: "anonymous", loadInHead: false, async: true, defer: false,
            cancellationToken: token);
    }

    private async ValueTask InitializeScript(CancellationToken token)
    {
        await _resourceLoader.WaitForVariable("Stripe", cancellationToken: token);
        _ = await _moduleImportUtil.GetContentModuleReference(_wrapperModulePath, token);
    }

    public async ValueTask LoadStripe(CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
            await _stripeJsInitializer.Init(linked);
    }

    public async ValueTask Initialize(CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await _stripeJsInitializer.Init(linked);
            await _scriptInitializer.Init(linked);
        }
    }

    public async ValueTask CreateObserver(string elementId, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_wrapperModulePath, linked);
            await module.InvokeVoidAsync("createObserver", linked, elementId);
        }
    }

    public async ValueTask Create(string elementId, DotNetObjectReference<StripeElements> dotNetObjectRef, StripeElementsConfiguration elementsConfiguration,
        CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await _scriptInitializer.Init(linked);
            string? json = JsonUtil.Serialize(elementsConfiguration);
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_wrapperModulePath, linked);
            await module.InvokeVoidAsync("create", linked, elementId, json, dotNetObjectRef);
        }
    }

    public async ValueTask<StripeConfirmResult?> ConfirmPayment(string elementId, string paymentIntentClientSecret, string returnUrl,
        CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_wrapperModulePath, linked);
            return await module.InvokeAsync<StripeConfirmResult?>("confirmPayment", linked, elementId, paymentIntentClientSecret, returnUrl);
        }
    }

    public async ValueTask<StripeSubmitResult?> Submit(string elementId, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_wrapperModulePath, linked);
            return await module.InvokeAsync<StripeSubmitResult?>("submit", linked, elementId);
        }
    }

    public async ValueTask<StripeConfirmResult?> ConfirmSetup(string elementId, string setupIntentClientSecret, string returnUrl,
        CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_wrapperModulePath, linked);
            return await module.InvokeAsync<StripeConfirmResult?>("confirmSetup", linked, elementId, setupIntentClientSecret, returnUrl);
        }
    }

    public async ValueTask Update(string elementId, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_wrapperModulePath, linked);
            await module.InvokeVoidAsync("update", linked, elementId);
        }
    }

    public async ValueTask Unmount(string elementId, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_wrapperModulePath, linked);
            await module.InvokeVoidAsync("unmountGroup", linked, elementId);
        }
    }

    public async ValueTask DisposeAsync()
    {
        await _moduleImportUtil.DisposeContentModule(_wrapperModulePath);
        await _scriptInitializer.DisposeAsync();
        await _cancellationScope.DisposeAsync();
    }
}