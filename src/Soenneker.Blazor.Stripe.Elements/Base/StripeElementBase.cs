using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using Soenneker.Blazor.Utils.Ids;
using Soenneker.Lepton.Suite;

namespace Soenneker.Blazor.Stripe.Elements.Base;

public abstract class StripeElementBase : LeptonIdentifiableElement
{
    [CascadingParameter]
    public Dictionary<Type, string>? ElementIds { get; set; }

    protected string ElementId =>
        ElementIds != null && ElementIds.TryGetValue(GetType(), out string? id)
            ? id
            : BlazorIdGenerator.New("stripe-element"); // fallback if not defined

    protected Dictionary<string, object> ElementAttributes
    {
        get
        {
            Dictionary<string, object> attributes = BuildAttributes();
            attributes["id"] = ElementId;
            return attributes;
        }
    }
}
