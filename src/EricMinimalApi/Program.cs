using EricDemo.MinimalApi.Simple;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapGet("/status", () => "V1 is running");
app.MapGet("/", () => "Welcome to Eric's Minimal API");

SimpleEndpoints.Map(app);
// BenchmarkEndpoints.Map(app);

app.Run();
