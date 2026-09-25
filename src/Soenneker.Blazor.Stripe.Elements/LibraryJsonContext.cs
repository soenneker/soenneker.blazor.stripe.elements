// Enum-value converters in referenced assemblies are file-local; explicit metadata below handles them.
using Soenneker.Blazor.Stripe.Elements.Configuration.Card;
using Soenneker.Blazor.Stripe.Elements.Configuration.Checkout;
using Soenneker.Blazor.Stripe.Elements.Configuration;
using Soenneker.Blazor.Stripe.Elements.Dtos;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;

namespace Soenneker.Blazor.Stripe.Elements;

[JsonSourceGenerationOptions(JsonSerializerDefaults.Web, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, ReadCommentHandling = JsonCommentHandling.Skip, UseStringEnumConverter = true, Converters = new[] { typeof(StripeAddressAutocompleteModeMetadataConverter), typeof(StripeAddressDisplayNameOptionMetadataConverter), typeof(StripeAddressFieldsPhoneOptionMetadataConverter), typeof(StripeAddressModeMetadataConverter), typeof(StripeAddressValidationPhoneRequiredMetadataConverter), typeof(StripeBillingAddressFieldOptionMetadataConverter), typeof(StripeCardElementIconStyleMetadataConverter), typeof(StripeDeveloperAssistantEnabledMetadataConverter), typeof(StripeElementsCaptureMethodMetadataConverter), typeof(StripeElementsLoaderMetadataConverter), typeof(StripeElementsModeMetadataConverter), typeof(StripeElementsSetupFutureUsageMetadataConverter), typeof(StripeElementsThemeMetadataConverter), typeof(StripeInputsModeMetadataConverter), typeof(StripeLabelsModeMetadataConverter), typeof(StripePaymentElementLayoutTypeMetadataConverter), typeof(StripeSyncAddressCheckboxOptionMetadataConverter), typeof(StripeTermsDisplayOptionMetadataConverter), typeof(StripeWalletDisplayOptionMetadataConverter) })]
[JsonSerializable(typeof(StripeCardBillingDetails))]
[JsonSerializable(typeof(StripeCheckoutConfirmOptions))]
[JsonSerializable(typeof(StripeElementsConfiguration))]
[JsonSerializable(typeof(object))]
[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(bool))]
[JsonSerializable(typeof(int))]
[JsonSerializable(typeof(long))]
[JsonSerializable(typeof(double))]
[JsonSerializable(typeof(decimal))]
[JsonSerializable(typeof(float))]
[JsonSerializable(typeof(System.Text.Json.JsonElement))]
[JsonSerializable(typeof(System.Collections.Generic.Dictionary<string, object?>))]
[JsonSerializable(typeof(System.Collections.Generic.List<object?>))]
[JsonSerializable(typeof(string[]))]
[JsonSerializable(typeof(object[]))]
internal partial class LibraryJsonContext : JsonSerializerContext
{
    internal static JsonTypeInfo<T> Get<T>() =>
        (JsonTypeInfo<T>)MetadataOptionsHolder.Value.GetTypeInfo(typeof(T));

    private static class MetadataOptionsHolder
    {
        internal static readonly JsonSerializerOptions Value = CreateMetadataOptions();
    }

    private static JsonSerializerOptions CreateMetadataOptions()
    {
        var options = new JsonSerializerOptions(Default.Options) { TypeInfoResolver = new MetadataResolver() };
        options.Converters.Add(new CurrencyCodeMetadataConverter());
        options.MakeReadOnly();
        return options;
    }

    private sealed class MetadataResolver : IJsonTypeInfoResolver
    {
        public JsonTypeInfo? GetTypeInfo(Type type, JsonSerializerOptions options)
        {
            if (type == typeof(Soenneker.Enums.CurrencyCodes.CurrencyCode))
                return JsonMetadataServices.CreateValueInfo<Soenneker.Enums.CurrencyCodes.CurrencyCode>(options, new CurrencyCodeMetadataConverter());
            return ((IJsonTypeInfoResolver)Default).GetTypeInfo(type, options);
        }
    }

    internal static JsonSerializerOptions WithContext(JsonSerializerContext? additionalContext)
    {
        JsonSerializerOptions defaults = Get<object>().Options;
        if (additionalContext is null)
            return defaults;
        var options = new JsonSerializerOptions(defaults)
        {
            TypeInfoResolver = JsonTypeInfoResolver.Combine(defaults.TypeInfoResolver!, additionalContext)
        };
        options.MakeReadOnly();
        return options;
    }
}

internal sealed class StripeAddressAutocompleteModeMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressAutocompleteMode>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressAutocompleteMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressAutocompleteMode.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeAddressAutocompleteMode value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressAutocompleteMode value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeAddressDisplayNameOptionMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressDisplayNameOption>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressDisplayNameOption Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressDisplayNameOption.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeAddressDisplayNameOption value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressDisplayNameOption value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeAddressFieldsPhoneOptionMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressFieldsPhoneOption>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressFieldsPhoneOption Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressFieldsPhoneOption.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeAddressFieldsPhoneOption value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressFieldsPhoneOption value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeAddressModeMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressMode>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressMode.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeAddressMode value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressMode value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeAddressValidationPhoneRequiredMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressValidationPhoneRequired>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressValidationPhoneRequired Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressValidationPhoneRequired.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeAddressValidationPhoneRequired value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeAddressValidationPhoneRequired value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeBillingAddressFieldOptionMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeBillingAddressFieldOption>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeBillingAddressFieldOption Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeBillingAddressFieldOption.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeBillingAddressFieldOption value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeBillingAddressFieldOption value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeCardElementIconStyleMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeCardElementIconStyle>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeCardElementIconStyle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeCardElementIconStyle.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeCardElementIconStyle value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeCardElementIconStyle value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeDeveloperAssistantEnabledMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeDeveloperAssistantEnabled>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeDeveloperAssistantEnabled Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeDeveloperAssistantEnabled.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeDeveloperAssistantEnabled value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeDeveloperAssistantEnabled value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeElementsCaptureMethodMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsCaptureMethod>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsCaptureMethod Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsCaptureMethod.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeElementsCaptureMethod value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsCaptureMethod value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeElementsLoaderMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsLoader>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsLoader Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsLoader.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeElementsLoader value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsLoader value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeElementsModeMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsMode>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsMode.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeElementsMode value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsMode value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeElementsSetupFutureUsageMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsSetupFutureUsage>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsSetupFutureUsage Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsSetupFutureUsage.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeElementsSetupFutureUsage value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsSetupFutureUsage value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeElementsThemeMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsTheme>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsTheme Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsTheme.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeElementsTheme value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeElementsTheme value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeInputsModeMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeInputsMode>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeInputsMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeInputsMode.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeInputsMode value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeInputsMode value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeLabelsModeMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeLabelsMode>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeLabelsMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeLabelsMode.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeLabelsMode value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeLabelsMode value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripePaymentElementLayoutTypeMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripePaymentElementLayoutType>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripePaymentElementLayoutType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripePaymentElementLayoutType.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripePaymentElementLayoutType value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripePaymentElementLayoutType value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeSyncAddressCheckboxOptionMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeSyncAddressCheckboxOption>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeSyncAddressCheckboxOption Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeSyncAddressCheckboxOption.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeSyncAddressCheckboxOption value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeSyncAddressCheckboxOption value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeTermsDisplayOptionMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeTermsDisplayOption>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeTermsDisplayOption Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeTermsDisplayOption.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeTermsDisplayOption value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeTermsDisplayOption value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class StripeWalletDisplayOptionMetadataConverter : JsonConverter<Soenneker.Blazor.Stripe.Elements.Enums.StripeWalletDisplayOption>
{
    public override Soenneker.Blazor.Stripe.Elements.Enums.StripeWalletDisplayOption Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Blazor.Stripe.Elements.Enums.StripeWalletDisplayOption.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown StripeWalletDisplayOption value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Blazor.Stripe.Elements.Enums.StripeWalletDisplayOption value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

internal sealed class CurrencyCodeMetadataConverter : JsonConverter<Soenneker.Enums.CurrencyCodes.CurrencyCode>
{
    public override Soenneker.Enums.CurrencyCodes.CurrencyCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType == JsonTokenType.String && Soenneker.Enums.CurrencyCodes.CurrencyCode.TryFromValue(reader.GetString(), out var value) ? value : throw new JsonException("Unknown CurrencyCode value.");

    public override void Write(Utf8JsonWriter writer, Soenneker.Enums.CurrencyCodes.CurrencyCode value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}
