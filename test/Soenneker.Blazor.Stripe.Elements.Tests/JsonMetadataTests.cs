using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using Soenneker.Blazor.Stripe.Elements.Configuration;
using Soenneker.Blazor.Stripe.Elements.Enums;
using Soenneker.Enums.CurrencyCodes;
using Soenneker.Utils.Json;
using System.Threading;

namespace Soenneker.Blazor.Stripe.Elements.Tests;

public class JsonMetadataTests
{
    [Test]
    [Arguments(false)]
    [Arguments(true)]
    public async ValueTask Generated_contract_preserves_local_and_package_enum_values(bool useDefaultOptions, CancellationToken cancellationToken)
    {
        var value = new StripeElementsConfiguration { PublishableKey = "pk_test" };
        value.ElementsOptions.Currency = CurrencyCode.Usd;
        value.ElementsOptions.Mode = StripeElementsMode.Payment;
        var metadata = LibraryJsonContext.Get<StripeElementsConfiguration>();
        string json = useDefaultOptions ? JsonUtil.Serialize(value)! : JsonUtil.Serialize(value, metadata);
        using JsonDocument document = JsonDocument.Parse(json);
        await Assert.That(document.RootElement.GetProperty("elementsOptions").GetProperty("currency").GetString()).IsEqualTo("usd");
        await Assert.That(document.RootElement.GetProperty("elementsOptions").GetProperty("mode").GetString()).IsEqualTo("payment");
        var result = (useDefaultOptions ? JsonUtil.Deserialize<StripeElementsConfiguration>(json) : JsonUtil.Deserialize(json, metadata))!;
        await Assert.That(result.ElementsOptions.Currency).IsEqualTo(CurrencyCode.Usd);
        await Assert.That(result.ElementsOptions.Mode).IsEqualTo(StripeElementsMode.Payment);
    }

    [Test]
    public async ValueTask Default_options_serialize_custom_object_values_without_a_context(CancellationToken cancellationToken)
    {
        string json = JsonUtil.Serialize(new AdditionalPayload { Name = "custom" })!;
        await Assert.That(json).IsEqualTo("{\"name\":\"custom\"}");
    }

    [Test]
    public async ValueTask Unknown_payload_requires_additional_generated_metadata(CancellationToken cancellationToken)
    {
        var value = new AdditionalPayload { Name = "custom" };
        await Assert.That(() => JsonUtil.Serialize<object>(value, LibraryJsonContext.Get<object>())).Throws<NotSupportedException>();
        JsonSerializerOptions options = LibraryJsonContext.WithContext(AdditionalJsonContext.Default);
        string json = JsonUtil.Serialize<object>(value, (JsonTypeInfo<object>)options.GetTypeInfo(typeof(object)));
        await Assert.That(json).IsEqualTo("{\"name\":\"custom\"}");
    }
}

public sealed class AdditionalPayload
{
    public string Name { get; set; } = "";
}

[JsonSourceGenerationOptions(JsonSerializerDefaults.Web)]
[JsonSerializable(typeof(AdditionalPayload))]
internal partial class AdditionalJsonContext : JsonSerializerContext;
