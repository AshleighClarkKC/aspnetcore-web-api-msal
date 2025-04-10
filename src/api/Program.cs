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
        }

        app.UseHttpsRedirection();

        if (app.Environment.IsProduction())
        {
            app.UseHsts();
            app.UseCors();
        }


        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
