namespace Kaleidocode.Gists.API.Extensions;

using Microsoft.AspNetCore.Cors.Infrastructure;

public static class CorsPolicyBuilderExtensions
{
    public static void SetAccessControlHeaders(this CorsPolicyBuilder cpb, string[]? headerCollection)
    {
        if ((bool) headerCollection?.AsEnumerable().Any()!) { cpb.WithHeaders(headerCollection); }
        else { cpb.AllowAnyHeader(); }
    }

    public static void SetAccessControlMethods(this CorsPolicyBuilder cpb, string[]? methodCollection)
    {
        if ((bool)methodCollection?.AsEnumerable().Any()!) { cpb.WithMethods(methodCollection); }
        else { cpb.AllowAnyMethod(); }
    }

    public static void SetAccessControlOrigins(this CorsPolicyBuilder cpb, string[]? originCollection)
    {
        if ((bool)originCollection?.AsEnumerable().Any()!) { cpb.WithOrigins(originCollection); }
        else { cpb.AllowAnyMethod(); }
    }
}
