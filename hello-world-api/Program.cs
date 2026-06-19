using HelloWorld.Api;

var builder = WebApplication.CreateBuilder(args);

// Cloud Foundry and similar platforms commonly provide the listening port
// through the PORT environment variable.
if (int.TryParse(Environment.GetEnvironmentVariable("PORT"), out var port))
{
    builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
}

var app = builder.Build();

app.MapGet("/", () => Results.Redirect("/api/hello"));
app.MapGet("/api/hello", () => Results.Text(GreetingService.GetMessage(), "text/plain"));
app.MapGet("/health", () => Results.Ok(new HealthResponse("Healthy")));

app.Run();

internal sealed record HealthResponse(string Status);

// Enables future integration tests with WebApplicationFactory<Program>.
public partial class Program
{
}
