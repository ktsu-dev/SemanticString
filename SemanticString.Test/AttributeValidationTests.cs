// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.Semantics.Test;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class AttributeValidationTests
{
	[TestMethod]
	public void StartsWith_ValidString_ReturnsTrue()
	{
		// Arrange
		TestStringWithPrefix testString = SemanticString.FromString<TestStringWithPrefix>("PrefixTestString");

		// Act & Assert
		Assert.IsTrue(testString.IsValid());
	}

	[TestMethod]
	public void StartsWith_InvalidString_ThrowsFormatException()
	{
		// Act & Assert
		Assert.ThrowsException<FormatException>(() => SemanticString.FromString<TestStringWithPrefix>("NoPrefixString"));
	}

	[TestMethod]
	public void EndsWith_ValidString_ReturnsTrue()
	{
		// Arrange
		TestStringWithSuffix testString = SemanticString.FromString<TestStringWithSuffix>("TestStringSuffix");

		// Act & Assert
		Assert.IsTrue(testString.IsValid());
	}

	[TestMethod]
	public void EndsWith_InvalidString_ThrowsFormatException()
	{
		// Act & Assert
		Assert.ThrowsException<FormatException>(() => SemanticString.FromString<TestStringWithSuffix>("NoSuffixString"));
	}

	[TestMethod]
	public void Contains_ValidString_ReturnsTrue()
	{
		// Arrange
		TestStringWithSubstring testString = SemanticString.FromString<TestStringWithSubstring>("Test_Contains_String");

		// Act & Assert
		Assert.IsTrue(testString.IsValid());
	}

	[TestMethod]
	public void Contains_InvalidString_ThrowsFormatException()
	{
		// Act & Assert
		Assert.ThrowsException<FormatException>(() => SemanticString.FromString<TestStringWithSubstring>("TestString"));
	}

	[TestMethod]
	public void PrefixAndSuffix_ValidString_ReturnsTrue()
	{
		// Arrange
		TestStringWithPrefixAndSuffix testString = SemanticString.FromString<TestStringWithPrefixAndSuffix>("PrefixTestSuffix");

		// Act & Assert
		Assert.IsTrue(testString.IsValid());
	}

	[TestMethod]
	public void PrefixAndSuffix_MissingPrefix_ThrowsFormatException()
	{
		// Act & Assert
		Assert.ThrowsException<FormatException>(() => SemanticString.FromString<TestStringWithPrefixAndSuffix>("TestSuffix"));
	}

	[TestMethod]
	public void PrefixAndSuffix_MissingSuffix_ThrowsFormatException()
	{
		// Act & Assert
		Assert.ThrowsException<FormatException>(() => SemanticString.FromString<TestStringWithPrefixAndSuffix>("PrefixTest"));
	}

	[TestMethod]
	public void RegexMatch_ValidString_ReturnsTrue()
	{
		// Arrange
		TestStringWithRegex testString = SemanticString.FromString<TestStringWithRegex>("abc123");

		// Act & Assert
		Assert.IsTrue(testString.IsValid());
	}

	[TestMethod]
	public void RegexMatch_InvalidString_ThrowsFormatException()
	{
		// Act & Assert
		Assert.ThrowsException<FormatException>(() => SemanticString.FromString<TestStringWithRegex>("123abc"));
	}

	[TestMethod]
	public void ValidateAny_OneValidAttribute_ReturnsTrue()
	{
		// Arrange
		TestStringWithAnyValidation testString = SemanticString.FromString<TestStringWithAnyValidation>("PrefixTest");

		// Act & Assert
		Assert.IsTrue(testString.IsValid());
	}

	[TestMethod]
	public void ValidateAny_AnotherValidAttribute_ReturnsTrue()
	{
		// Arrange
		TestStringWithAnyValidation testString = SemanticString.FromString<TestStringWithAnyValidation>("TestSuffix");

		// Act & Assert
		Assert.IsTrue(testString.IsValid());
	}

	[TestMethod]
	public void ValidateAny_NoValidAttributes_ThrowsFormatException()
	{
		// Act & Assert
		Assert.ThrowsException<FormatException>(() => SemanticString.FromString<TestStringWithAnyValidation>("JustATest"));
	}

	[TestMethod]
	public void ValidateAll_AllValidAttributes_ReturnsTrue()
	{
		// Arrange
		TestStringWithAllValidation testString = SemanticString.FromString<TestStringWithAllValidation>("PrefixTestSuffix");

		// Act & Assert
		Assert.IsTrue(testString.IsValid());
	}

	[TestMethod]
	public void ValidateAll_OneInvalidAttribute_ThrowsFormatException()
	{
		// Act & Assert
		Assert.ThrowsException<FormatException>(() => SemanticString.FromString<TestStringWithAllValidation>("TestSuffix"));
	}
}

[StartsWith("Prefix")]
public record TestStringWithPrefix : SemanticString<TestStringWithPrefix> { }

[EndsWith("Suffix")]
public record TestStringWithSuffix : SemanticString<TestStringWithSuffix> { }

[Contains("_Contains_")]
public record TestStringWithSubstring : SemanticString<TestStringWithSubstring> { }

[PrefixAndSuffix("Prefix", "Suffix")]
public record TestStringWithPrefixAndSuffix : SemanticString<TestStringWithPrefixAndSuffix> { }

[RegexMatch("^[a-z]+[0-9]+$")]
public record TestStringWithRegex : SemanticString<TestStringWithRegex> { }

[ValidateAny]
[StartsWith("Prefix")]
[EndsWith("Suffix")]
public record TestStringWithAnyValidation : SemanticString<TestStringWithAnyValidation> { }

[ValidateAll]
[StartsWith("Prefix")]
[EndsWith("Suffix")]
public record TestStringWithAllValidation : SemanticString<TestStringWithAllValidation> { }
