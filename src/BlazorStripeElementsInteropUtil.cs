using Soenneker.Blazor.Stripe.Elements.Abstract;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Soenneker.Blazor.Stripe.Elements;

/// <inheritdoc cref="IBlazorStripeElementsInteropUtil"/>
public class BlazorStripeElementsInteropUtil: IBlazorStripeElementsInteropUtil
{
    private readonly IJSRuntime _jsRuntime;
    private readonly ILogger<BlazorStripeElementsInteropUtil> _logger;

    public BlazorStripeElementsInteropUtil(IJSRuntime jSRuntime, ILogger<BlazorStripeElementsInteropUtil> logger)
    {
        _jsRuntime = jSRuntime;
        _logger = logger;
    }
}
