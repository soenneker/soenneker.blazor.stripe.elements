using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using Soenneker.Quark;

namespace Soenneker.Blazor.Stripe.Elements.Base;

public abstract class StripeElementBase : CoreComponent
{
    [CascadingParameter]
    public Dictionary<Type, string>? ElementIds { get; set; }

    protected string ElementId =>
        ElementIds != null && ElementIds.TryGetValue(GetType(), out string? id)
            ? id
            : $"auto-{Guid.NewGuid()}"; // fallback if not defined
}
