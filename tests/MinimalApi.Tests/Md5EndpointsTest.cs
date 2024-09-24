using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using EricDemo.SharedLibrary.BenchMark;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using System.Text;

namespace EricDemo.MinimalApi.Benchmark.Tests
{
	public class Md5EndpointsTests : IClassFixture<WebApplicationFactory<Program>>
	{
		private readonly WebApplicationFactory<Program> _factory;
		private readonly JsonSerializerOptions _jsonSerializerOptions;

		public Md5EndpointsTests(WebApplicationFactory<Program> factory)
		{
			_factory = factory;
			_jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
		}

		// Helper method to create an authenticated client
		private HttpClient GetAuthenticatedClient()
		{
			HttpClient? client = _factory.CreateClient();
			string username = "Eric";
			string password = "Cheng";
			string authInfo = $"{username}:{password}";
			byte[] authBytes = Encoding.ASCII.GetBytes(authInfo);
			string base64Auth = Convert.ToBase64String(authBytes);
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Auth);
			return client;
		}

		[Theory]
		[InlineData(0, "exeTimes must be greater than 0")]
		[InlineData(-5, "exeTimes must be greater than 0")]
		[InlineData(1000001, "exeTimes must be less than 1,000,000")]
		[InlineData(2000000, "exeTimes must be less than 1,000,000")]
		public async Task GetMd5_InvalidExeTimes_ReturnsBadRequest(int exeTimes, string expectedMessage)
		{
			// Arrange
			HttpClient client = GetAuthenticatedClient();
			string url = $"/benchmark/Md5/{exeTimes}";

			// Act
			HttpResponseMessage response = await client.GetAsync(url);

			// Assert
			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
			string content = await response.Content.ReadAsStringAsync();
			string? actualMessage = JsonSerializer.Deserialize<string>(content);

			actualMessage.Should().Be(expectedMessage);
		}

		[Fact]
		public async Task GetMd5_ValidExeTimes_ReturnsOk()
		{
			// Arrange
			int exeTimes = 1000;
			HttpClient client = GetAuthenticatedClient();
			string url = $"/benchmark/Md5/{exeTimes}";

			// Act
			HttpResponseMessage response = await client.GetAsync(url);

			// Assert
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			string content = await response.Content.ReadAsStringAsync();

			// Deserialize the response
			BenchMarkTestResult? result = JsonSerializer.Deserialize<BenchMarkTestResult>(content, _jsonSerializerOptions);

			result.Should().NotBeNull();
			result?.Server.Should().Be(Constants.ServerName);
		}

		[Fact]
		public async Task GetMd5_Unauthorized_ReturnsUnauthorized()
		{
			// Arrange
			int exeTimes = 1000;
			HttpClient client = _factory.CreateClient(); // No authentication
			string url = $"/benchmark/Md5/{exeTimes}";

			// Act
			HttpResponseMessage response = await client.GetAsync(url);

			// Assert
			response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
		}
	}
}
