using EricDemo.MinimalApi.Simple;
using EricDemo.MinimalApi.Benchmark;
using EricDemo.SharedLibrary.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace EricDemo.MinimalApi;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
		builder.Services.AddAuthorization();
		var app = builder.Build();

		app.UseAuthentication();
		app.UseAuthorization();

		string? appVersion = builder.Configuration["AppVersion"];

		app.MapGet("/", () => "Welcome to Eric's Minimal API Demo");
		app.MapGet("/status", () => $"Version {appVersion} is running");

		SimpleEndpoints.Map(app);
		BenchmarkEndpoints.Map(app);

		app.Run();
	}
}