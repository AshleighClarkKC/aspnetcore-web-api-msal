namespace Kaleidocode.Gists.API;

using Kaleidocode.Gists.API.Extensions;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddMicrosoftWebApiAuthentication(builder.Configuration);
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        WebApplication? app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // TODO: Investigate usage of HSTS.
            app.UseHsts();

        }

        app.UseCors(
                // TODO: Convert Headers/Origins from Configuration to Database Calls to Allow for Dynamic Additions.
                // TODO: onChange of Values from DB, an Event will need to be fired to update this. This check will need to happen onListen for calls. 
                cpb =>
                {
                    cpb.SetAccessControlHeaders(
                        builder.Configuration.GetArray("AccessControl:AllowedHeaders")
                    );
                    cpb.SetAccessControlMethods(
                        builder.Configuration.GetArray("AccessControl:AllowedMethods")
                    );
                    cpb.SetAccessControlOrigins(
                        builder.Configuration.GetArray("AccessControl:AllowedOrigins")
                    );
                }
            );

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }

}
