namespace Kaleidocode.Gists.API.Extensions;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddMicrosoftWebApiAuthentication(this IServiceCollection svc, IConfiguration cfg)
    {
        svc
            .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(configuration: cfg, configSectionName: "AzureAd", jwtBearerScheme: JwtBearerDefaults.AuthenticationScheme);

        return svc;
    }
}

