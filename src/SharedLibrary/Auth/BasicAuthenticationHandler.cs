using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EricDemo.SharedLibrary.Auth;
public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
	// declare a string key pair list for storing username and password
	private readonly List<KeyValuePair<string, string>> _users = new()
	{
		new KeyValuePair<string, string>("Eric", "Cheng"),
		new KeyValuePair<string, string>("Korina", "Cheng"),
		new KeyValuePair<string, string>("Tonia", "Cheng")
	};

	public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
		: base(options, logger, encoder, clock)
	{
	}

	protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
	{
		if (!Request.Headers.ContainsKey("Authorization")) {
			return AuthenticateResult.Fail("Missing Authorization Header");
		}

		string username, password;
		try
		{
			var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
			var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
			var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
			username = credentials[0];
			password = credentials[1];
		}
		catch
		{
			return AuthenticateResult.Fail("Invalid Authorization Header");
		}

		// check username and password against the list _users
		if (!_users.Any(u => u.Key == username && u.Value == password)) {
			return AuthenticateResult.Fail("Invalid Username or Password");
		}

		var claims = new[] {
			new Claim(ClaimTypes.NameIdentifier, username),
			new Claim(ClaimTypes.Name, username),
		};
		var identity = new ClaimsIdentity(claims, Scheme.Name);
		var principal = new ClaimsPrincipal(identity);
		var ticket = new AuthenticationTicket(principal, Scheme.Name);

		return AuthenticateResult.Success(ticket);
	}
}