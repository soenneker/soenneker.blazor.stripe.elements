using Soenneker.Blazor.Stripe.Elements.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Blazor.Stripe.Elements.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class BlazorStripeElementsInteropUtilTests : HostedUnitTest
{
    private readonly IStripeElementsInterop _blazorlibrary;

    public BlazorStripeElementsInteropUtilTests(Host host) : base(host)
    {
        _blazorlibrary = Resolve<IStripeElementsInterop>(true);
    }

    [Test]
    public void Default()
    {

    }
}
