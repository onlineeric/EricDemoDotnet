using EricDemo.MinimalApi.Simple;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

string appVersion = builder.Configuration["AppVersion"];

app.MapGet("/status", () => $"Version {appVersion} is running");
app.MapGet("/", () => "Welcome to Eric's Minimal API Demo");

SimpleEndpoints.Map(app);
BenchmarkEndpoints.Map(app);

app.Run();
