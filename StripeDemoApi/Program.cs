using StripeDemoApi.Models;

namespace StripeDemoApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        // 1. Adds services for generating an OpenAPI specification.
        builder.Services.AddEndpointsApiExplorer();
        // 2. Adds Swashbuckle services and configures Swagger generation.
        builder.Services.AddSwaggerGen();

        // This line registers the StripeOptions class and binds it
        // to the "Stripe" section in your appsettings.json file.
        builder.Services.Configure<StripeOptions>(builder.Configuration.GetSection(
            StripeOptions.Stripe));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            // Replace the MapOpenApi() call with these two lines for Swagger UI.
            // 1. Serves the generated OpenAPI specification as a JSON endpoint.
            app.UseSwagger();
            // 2. Serves the Swagger UI at the /swagger endpoint.
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}