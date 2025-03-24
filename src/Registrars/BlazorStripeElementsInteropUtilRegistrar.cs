using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Blazor.Stripe.Elements.Abstract;

namespace Soenneker.Blazor.Stripe.Elements.Registrars;

/// <summary>
/// A Blazor interop library for Stripe Elements
/// </summary>
public static class BlazorStripeElementsInteropUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IBlazorStripeElementsInteropUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddBlazorStripeElementsInteropUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IBlazorStripeElementsInteropUtil, BlazorStripeElementsInteropUtil>();

        return services;
    }
}
