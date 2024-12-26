namespace ktsu.Semantics.Test;

[TestClass]
public class SemanticStringTests
{
	public record MySemanticString : SemanticString<MySemanticString> { }

	public abstract class StartsWithHttp : ISemanticStringValidator
	{
		public static bool IsValid(ISemanticString? semanticString)
		{
			return semanticString?.StartsWith("http", StringComparison.InvariantCultureIgnoreCase) ?? false;
		}
	}

	public abstract class EndsWithDotCom : ISemanticStringValidator
	{
		public static bool IsValid(ISemanticString? semanticString)
		{
			return semanticString?.EndsWith(".com", StringComparison.InvariantCultureIgnoreCase) ?? false;
		}
	}

	public record MyValidatedString : SemanticString<MyValidatedString, StartsWithHttp, EndsWithDotCom> { }

	[TestMethod]
	public void ImplicitCastToString()
	{
		var semanticString = SemanticString.FromString<MySemanticString>("test");
		string systemString = semanticString;
		Assert.AreEqual("test", systemString);
	}

	[TestMethod]
	public void ExplicitCastFromString()
	{
		string systemString = "test";
		var semanticString = (MySemanticString)systemString;
		Assert.AreEqual("test", semanticString.WeakString);
	}

	[TestMethod]
	public void ToStringMethod()
	{
		var semanticString = SemanticString.FromString<MySemanticString>("test");
		Assert.AreEqual("test", semanticString.ToString());
	}

	private static readonly char[] TestCharArray = ['t', 'e', 's', 't'];

	[TestMethod]
	public void ToCharArrayMethod()
	{
		var semanticString = SemanticString.FromString<MySemanticString>("test");
		char[] chars = semanticString.ToCharArray();
		CollectionAssert.AreEqual(TestCharArray, chars);
	}

	[TestMethod]
	public void IsEmptyMethod()
	{
		var semanticString = SemanticString.FromString<MySemanticString>(string.Empty);
		Assert.IsTrue(semanticString.IsEmpty());
	}

	[TestMethod]
	public void IsValidMethod()
	{
		var semanticString = SemanticString.FromString<MySemanticString>("test");
		Assert.IsTrue(semanticString.IsValid());
	}

	[TestMethod]
	public void ValidatedStringIsValid()
	{
		var semanticString = SemanticString.FromString<MyValidatedString>("http://example.com");
		Assert.IsTrue(semanticString.IsValid());
	}

	[TestMethod]
	public void ValidatedStringIsInvalid()
	{
		Assert.ThrowsException<FormatException>(() => SemanticString.FromString<MyValidatedString>("invalid"));
	}

	[TestMethod]
	public void WithPrefixMethod()
	{
		var semanticString = SemanticString.FromString<MySemanticString>("test");
		var result = semanticString.WithPrefix("pre-");
		Assert.AreEqual("pre-test", result.ToString());
	}

	[TestMethod]
	public void WithSuffixMethod()
	{
		var semanticString = SemanticString.FromString<MySemanticString>("test");
		var result = semanticString.WithSuffix("-post");
		Assert.AreEqual("test-post", result.ToString());
	}
	[TestMethod]
	public void AsStringExtensionMethod()
	{
		string systemString = "test";
		var semanticString = systemString.As<MySemanticString>();
		Assert.AreEqual("test", semanticString.WeakString);
	}

	[TestMethod]
	public void AsCharArrayExtensionMethod()
	{
		char[] charArray = ['t', 'e', 's', 't'];
		var semanticString = charArray.As<MySemanticString>();
		CollectionAssert.AreEqual(charArray, semanticString.ToCharArray());
	}

	[TestMethod]
	public void AsReadOnlySpanExtensionMethod()
	{
		var span = "test".AsSpan();
		var semanticString = span.As<MySemanticString>();
		Assert.AreEqual("test", semanticString.WeakString);
	}

	[TestMethod]
	public void ValidatedStringWithPrefix()
	{
		var semanticString = SemanticString.FromString<MyValidatedString>("http://example.com");
		var result = semanticString.WithPrefix("https://");
		Assert.AreEqual("https://http://example.com", result.ToString());
	}

	[TestMethod]
	public void ValidatedStringWithSuffix()
	{
		var semanticString = SemanticString.FromString<MyValidatedString>("http://example.com");
		var result = semanticString.WithSuffix("/index.html.com");
		Assert.AreEqual("http://example.com/index.html.com", result.ToString());
	}

	[TestMethod]
	public void ValidatedStringWithInvalidPrefix()
	{
		Assert.ThrowsException<FormatException>(() => SemanticString.FromString<MyValidatedString>("ftp://example.com"));
	}

	[TestMethod]
	public void ValidatedStringWithInvalidSuffix()
	{
		Assert.ThrowsException<FormatException>(() => SemanticString.FromString<MyValidatedString>("http://example.org"));
	}
}
