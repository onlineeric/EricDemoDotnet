var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/status", () => "V1 is running");
app.MapGet("/", () => "Welcome to Eric's Minimal API");

app.Run();
