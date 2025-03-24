using Soenneker.Blazor.Stripe.Elements.Abstract;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace Soenneker.Blazor.Stripe.Elements;

/// <inheritdoc cref="IStripeElementsInterop"/>
public class StripeElementsInterop: IStripeElementsInterop
{
    private readonly IJSRuntime _jsRuntime;
    private readonly ILogger<StripeElementsInterop> _logger;

    public StripeElementsInterop(IJSRuntime jSRuntime, ILogger<StripeElementsInterop> logger)
    {
        _jsRuntime = jSRuntime;
        _logger = logger;
    }
}
