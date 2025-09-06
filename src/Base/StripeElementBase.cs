using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Soenneker.Blazor.Stripe.Elements.Base;

public abstract class StripeElementBase : ComponentBase
{
    [CascadingParameter]
    public Dictionary<Type, string>? ElementIds { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object?>? Attributes { get; set; }

    protected string ElementId =>
        ElementIds != null && ElementIds.TryGetValue(GetType(), out string? id)
            ? id
            : $"auto-{Guid.NewGuid()}"; // fallback if not defined
}
