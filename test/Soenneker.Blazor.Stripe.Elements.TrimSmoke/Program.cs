using System.Text.Json;
using Soenneker.Blazor.Stripe.Elements;

var result = JsonSerializer.Deserialize("""{"paymentIntent":{"id":"pi_test","status":"succeeded"},"setupIntent":{"id":"seti_test","status":"requires_action"},"error":{"message":"declined"}}""", InteropJsonContext.Default.StripeConfirmResult)!;
Check(result.PaymentIntent is { Id: "pi_test", Status: "succeeded" } && result.SetupIntent is { Id: "seti_test" }, "nested Stripe intents");
Check(result.Error?.Message == "declined", "nested Stripe error");
var submit = JsonSerializer.Deserialize("""{"error":{"message":"invalid"}}""", InteropJsonContext.Default.StripeSubmitResult)!;
Check(submit.Error?.Message == "invalid", "submit error");
var card = JsonSerializer.Deserialize("""{"complete":false,"brand":"visa","error":{"message":"incomplete"}}""", InteropJsonContext.Default.StripeCardElementChangeResult)!;
Check(card.Brand == "visa" && card.Error?.Message == "incomplete", "card change error");

Console.WriteLine("Trimmed JSON smoke checks passed.");

static void Check(bool condition, string name)
{
    if (!condition) throw new InvalidOperationException(name);
}
