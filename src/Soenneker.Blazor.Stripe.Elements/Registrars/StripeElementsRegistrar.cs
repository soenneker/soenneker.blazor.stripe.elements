using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Blazor.Stripe.Elements.Abstract;
using Soenneker.Blazor.Utils.InteropEventListener.Registrars;
using Soenneker.Blazor.Utils.ResourceLoader.Registrars;

namespace Soenneker.Blazor.Stripe.Elements.Registrars;

/// <summary>
/// A Blazor interop library for Stripe Elements
/// </summary>
public static class StripeElementsRegistrar
{
    /// <summary>
    /// Adds <see cref="IStripeElementsInterop"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddStripeElementsInteropAsScoped(this IServiceCollection services)
    {
        services.AddResourceLoaderAsScoped().AddInteropEventListenerAsScoped().TryAddScoped<IStripeElementsInterop, StripeElementsInterop>();

        return services;
    }
}
