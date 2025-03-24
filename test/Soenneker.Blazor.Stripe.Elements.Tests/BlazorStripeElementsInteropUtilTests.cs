using Soenneker.Blazor.Stripe.Elements.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Blazor.Stripe.Elements.Tests;

[Collection("Collection")]
public class BlazorStripeElementsInteropUtilTests : FixturedUnitTest
{
    private readonly IStripeElementsInterop _blazorlibrary;

    public BlazorStripeElementsInteropUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _blazorlibrary = Resolve<IStripeElementsInterop>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
