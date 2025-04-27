namespace ktsu.Semantics.Demo;

// Define some example SemanticString types with attribute validation

/// <summary>
/// Represents a URL string that must start with either "http://" or "https://".
/// </summary>
[StartsWith("http://", StringComparison.OrdinalIgnoreCase)]
[StartsWith("https://", StringComparison.OrdinalIgnoreCase)]
public record class UrlString : SemanticString<UrlString> { }

/// <summary>
/// Represents a domain name that must end with ".com".
/// </summary>
[EndsWith(".com", StringComparison.OrdinalIgnoreCase)]
public record class DotComDomain : SemanticString<DotComDomain> { }

/// <summary>
/// Represents a domain name that must end with either ".com", ".org", or ".net".
/// Uses ValidateAny to allow any of these top-level domains.
/// </summary>
[ValidateAny]
[EndsWith(".com", StringComparison.OrdinalIgnoreCase)]
[EndsWith(".org", StringComparison.OrdinalIgnoreCase)]
[EndsWith(".net", StringComparison.OrdinalIgnoreCase)]
public record class TopLevelDomain : SemanticString<TopLevelDomain> { }

/// <summary>
/// Represents a valid email address that matches standard email format.
/// </summary>
[RegexMatch(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
public record class EmailAddress : SemanticString<EmailAddress> { }

/// <summary>
/// Demonstrates the validation functionality of SemanticString types.
/// </summary>
public static class DemoProgram
{
	/// <summary>
	/// Runs a demonstration of various SemanticString validations including URLs, domains, and email addresses.
	/// Shows both successful and failed validation scenarios.
	/// </summary>
	public static void ShowDemo()
	{
		Console.WriteLine("SemanticString Validation Demo");
		Console.WriteLine("-----------------------------");

		// UrlString demo
		try
		{
			Console.WriteLine("\nTesting URL validation:");
			Console.WriteLine("  Valid: 'https://example.com'");
			var validUrl = SemanticString.FromString<UrlString>("https://example.com");
			Console.WriteLine("  Result: ✓ Valid");

			Console.WriteLine("  Invalid: 'ftp://example.com'");
			var invalidUrl = SemanticString.FromString<UrlString>("ftp://example.com");
			Console.WriteLine("  Result: ✓ Valid (shouldn't reach here)");
		}
		catch (FormatException)
		{
			Console.WriteLine("  Result: ✗ Invalid (correct)");
		}

		// TopLevelDomain demo
		try
		{
			Console.WriteLine("\nTesting ValidateAny with multiple domains:");
			Console.WriteLine("  Valid: 'example.org'");
			var validOrg = SemanticString.FromString<TopLevelDomain>("example.org");
			Console.WriteLine("  Result: ✓ Valid");

			Console.WriteLine("  Invalid: 'example.io'");
			var invalidDomain = SemanticString.FromString<TopLevelDomain>("example.io");
			Console.WriteLine("  Result: ✓ Valid (shouldn't reach here)");
		}
		catch (FormatException)
		{
			Console.WriteLine("  Result: ✗ Invalid (correct)");
		}

		// Email validation demo
		try
		{
			Console.WriteLine("\nTesting Email validation with regex:");
			Console.WriteLine("  Valid: 'user@example.com'");
			var validEmail = SemanticString.FromString<EmailAddress>("user@example.com");
			Console.WriteLine("  Result: ✓ Valid");

			Console.WriteLine("  Invalid: 'not-an-email'");
			var invalidEmail = SemanticString.FromString<EmailAddress>("not-an-email");
			Console.WriteLine("  Result: ✓ Valid (shouldn't reach here)");
		}
		catch (FormatException)
		{
			Console.WriteLine("  Result: ✗ Invalid (correct)");
		}

		Console.WriteLine("\nDemo completed successfully!");
	}
}
