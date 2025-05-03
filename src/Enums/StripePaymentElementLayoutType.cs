using Intellenum;

namespace Soenneker.Blazor.Stripe.Elements.Enums
{
    /// <summary>
    /// Defines the layout type for the Stripe Payment Element: "accordion" or "tabs".
    /// </summary>
    [Intellenum<string>]
    public partial class StripePaymentElementLayoutType
    {
        public static readonly StripePaymentElementLayoutType Accordion = new("accordion");
        public static readonly StripePaymentElementLayoutType Tabs = new("tabs");
    }
}
