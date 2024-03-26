using EricDemo.MinimalApi.Simple;
using EricDemo.MinimalApi.Benchmark;
using EricDemo.SharedLibrary.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddAuthorization();
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();

string? appVersion = builder.Configuration["AppVersion"];

app.MapGet("/", () => "Welcome to Eric's Minimal API Demo");
app.MapGet("/status", () => $"Version {appVersion} is running");

SimpleEndpoints.Map(app);
BenchmarkEndpoints.Map(app);

app.Run();
