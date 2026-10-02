using Soenneker.Stripe.Dtos.JsError;
using System.Text.Json;
using System.Threading.Tasks;
using Soenneker.Blazor.Stripe.Elements.Dtos;

namespace Soenneker.Blazor.Stripe.Elements.Tests;

public class StripeJsErrorTests
{
    private static readonly JsonSerializerOptions Options = new(JsonSerializerDefaults.Web);

    [Test]
    [Arguments("validation_error")]
    [Arguments("api_connection_error")]
    [Arguments("future_error")]
    public async Task Browser_errors_reach_all_result_types(string errorType)
    {
        string json = $$$"""{"error":{"type":"{{{errorType}}}","code":"future_code","decline_code":"future_decline","message":"Payment details need attention."}}""";
        StripeJsError?[] errors =
        [
            JsonSerializer.Deserialize<StripeSubmitResult>(json, Options)!.Error,
            JsonSerializer.Deserialize<StripeConfirmResult>(json, Options)!.Error,
            JsonSerializer.Deserialize<StripeValidationResult>(json, Options)!.Error,
            JsonSerializer.Deserialize<StripeCardElementChangeResult>(json, Options)!.Error
        ];

        foreach (StripeJsError? error in errors)
        {
            await Assert.That(error!.Type).IsEqualTo(errorType);
            await Assert.That(error.Code).IsEqualTo("future_code");
            await Assert.That(error.DeclineCode).IsEqualTo("future_decline");
            await Assert.That(error.Message).IsEqualTo("Payment details need attention.");
        }
    }

    [Test]
    public async Task Expanded_error_objects_are_preserved()
    {
        const string json = """
            {"error":{"type":"card_error","code":"card_declined","message":"Declined",
            "payment_intent":{"id":"pi_test","status":"requires_payment_method","amount":10000},
            "setup_intent":{"id":"seti_test"},"payment_method":{"id":"pm_test"},"source":{"id":"src_test"}}}
            """;
        StripeJsError error = JsonSerializer.Deserialize<StripeConfirmResult>(json, Options)!.Error!;
        await Assert.That(error.PaymentIntent!.Value.GetProperty("id").GetString()).IsEqualTo("pi_test");
        await Assert.That(error.PaymentIntent.Value.GetProperty("amount").GetInt32()).IsEqualTo(10000);
        await Assert.That(error.SetupIntent!.Value.GetProperty("id").GetString()).IsEqualTo("seti_test");
        await Assert.That(error.PaymentMethod!.Value.GetProperty("id").GetString()).IsEqualTo("pm_test");
        await Assert.That(error.Source!.Value.GetProperty("id").GetString()).IsEqualTo("src_test");
        await Assert.That(error.Message).IsEqualTo("Declined");
    }

    [Test]
    public async Task Successful_results_still_deserialize()
    {
        StripeSubmitResult submit = JsonSerializer.Deserialize<StripeSubmitResult>("{}", Options)!;
        StripeConfirmResult confirmation = JsonSerializer.Deserialize<StripeConfirmResult>(
            """{"paymentIntent":{"id":"pi_test","status":"succeeded"}}""", Options)!;
        await Assert.That(submit.Error).IsNull();
        await Assert.That(confirmation.Error).IsNull();
        await Assert.That(confirmation.PaymentIntent!.Status).IsEqualTo("succeeded");
    }
}
