using System.Text.Json;
using System.Text.Json.Serialization;
using Soenneker.Blazor.Stripe.Elements.Dtos;

namespace Soenneker.Blazor.Stripe.Elements;

[JsonSourceGenerationOptions(JsonSerializerDefaults.Web)]
[JsonSerializable(typeof(StripeConfirmResult))]
[JsonSerializable(typeof(StripeSubmitResult))]
[JsonSerializable(typeof(StripeCardElementChangeResult))]
internal partial class InteropJsonContext : JsonSerializerContext;
