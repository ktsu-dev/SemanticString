#pragma warning disable CS1591

namespace ktsu.Semantics;

using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

[DebuggerDisplay(value: $"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public abstract record SemanticString : ISemanticString
{
	public TDest As<TDest>()
		where TDest : SemanticString
		=> FromString<TDest>(WeakString);

	protected virtual string MakeCanonical(string input)
		=> input;

	public char[] ToCharArray() => ToCharArray(semanticString: this);

	// ISemanticString implementation
	public string WeakString { get; init; } = string.Empty;

	public int Length => WeakString.Length;

	public char this[int index] => WeakString[index: index];

	public int CompareTo(object? value) => WeakString.CompareTo(value: value);

	public bool Contains(string value) => WeakString.Contains(value: value);

	public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count) => WeakString.CopyTo(sourceIndex: sourceIndex, destination: destination, destinationIndex: destinationIndex, count: count);

	public bool EndsWith(string value) => WeakString.EndsWith(value: value);

	public bool EndsWith(string value, bool ignoreCase, CultureInfo culture) => WeakString.EndsWith(value: value, ignoreCase: ignoreCase, culture: culture);

	public bool EndsWith(string value, StringComparison comparisonType) => WeakString.EndsWith(value: value, comparisonType: comparisonType);

	public bool Equals(string value) => WeakString.Equals(value: value);

	public bool Equals(string value, StringComparison comparisonType) => WeakString.Equals(value: value, comparisonType: comparisonType);

	public CharEnumerator GetEnumerator() => WeakString.GetEnumerator();

	public TypeCode GetTypeCode() => WeakString.GetTypeCode();

	public int IndexOf(char value) => WeakString.IndexOf(value: value);

	public int IndexOf(char value, int startIndex) => WeakString.IndexOf(value: value, startIndex: startIndex);

	public int IndexOf(char value, int startIndex, int count) => WeakString.IndexOf(value: value, startIndex: startIndex, count: count);

	public int IndexOf(string value) => WeakString.IndexOf(value: value);

	public int IndexOf(string value, int startIndex) => WeakString.IndexOf(value: value, startIndex: startIndex);

	public int IndexOf(string value, int startIndex, int count) => WeakString.IndexOf(value: value, startIndex: startIndex, count: count);

	public int IndexOf(string value, int startIndex, int count, StringComparison comparisonType) => WeakString.IndexOf(value: value, startIndex: startIndex, count: count, comparisonType: comparisonType);

	public int IndexOf(string value, int startIndex, StringComparison comparisonType) => WeakString.IndexOf(value: value, startIndex: startIndex, comparisonType: comparisonType);

	public int IndexOf(string value, StringComparison comparisonType) => WeakString.IndexOf(value: value, comparisonType: comparisonType);

	public int IndexOfAny(char[] anyOf) => WeakString.IndexOfAny(anyOf: anyOf);

	public int IndexOfAny(char[] anyOf, int startIndex) => WeakString.IndexOfAny(anyOf: anyOf, startIndex: startIndex);

	public int IndexOfAny(char[] anyOf, int startIndex, int count) => WeakString.IndexOfAny(anyOf: anyOf, startIndex: startIndex, count: count);

	public string Insert(int startIndex, string value) => WeakString.Insert(startIndex: startIndex, value: value);

	public bool IsNormalized() => WeakString.IsNormalized();

	public bool IsNormalized(NormalizationForm normalizationForm) => WeakString.IsNormalized(normalizationForm: normalizationForm);

	public int LastIndexOf(char value) => WeakString.LastIndexOf(value: value);

	public int LastIndexOf(char value, int startIndex) => WeakString.LastIndexOf(value: value, startIndex: startIndex);

	public int LastIndexOf(char value, int startIndex, int count) => WeakString.LastIndexOf(value: value, startIndex: startIndex, count: count);

	public int LastIndexOf(string value) => WeakString.LastIndexOf(value: value);

	public int LastIndexOf(string value, int startIndex) => WeakString.LastIndexOf(value: value, startIndex: startIndex);

	public int LastIndexOf(string value, int startIndex, int count) => WeakString.LastIndexOf(value: value, startIndex: startIndex, count: count);

	public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType) => WeakString.LastIndexOf(value: value, startIndex: startIndex, count: count, comparisonType: comparisonType);

	public int LastIndexOf(string value, int startIndex, StringComparison comparisonType) => WeakString.LastIndexOf(value: value, startIndex: startIndex, comparisonType: comparisonType);

	public int LastIndexOf(string value, StringComparison comparisonType) => WeakString.LastIndexOf(value: value, comparisonType: comparisonType);

	public int LastIndexOfAny(char[] anyOf) => WeakString.LastIndexOfAny(anyOf: anyOf);

	public int LastIndexOfAny(char[] anyOf, int startIndex) => WeakString.LastIndexOfAny(anyOf: anyOf, startIndex: startIndex);

	public int LastIndexOfAny(char[] anyOf, int startIndex, int count) => WeakString.LastIndexOfAny(anyOf: anyOf, startIndex: startIndex, count: count);

	public string Normalize() => WeakString.Normalize();

	public string Normalize(NormalizationForm normalizationForm) => WeakString.Normalize(normalizationForm: normalizationForm);

	public string PadLeft(int totalWidth) => WeakString.PadLeft(totalWidth: totalWidth);

	public string PadLeft(int totalWidth, char paddingChar) => WeakString.PadLeft(totalWidth: totalWidth, paddingChar: paddingChar);

	public string PadRight(int totalWidth) => WeakString.PadRight(totalWidth: totalWidth);

	public string PadRight(int totalWidth, char paddingChar) => WeakString.PadRight(totalWidth: totalWidth, paddingChar: paddingChar);

	public string Remove(int startIndex) => WeakString.Remove(startIndex: startIndex);

	public string Remove(int startIndex, int count) => WeakString.Remove(startIndex: startIndex, count: count);

	public string Replace(char oldChar, char newChar) => WeakString.Replace(oldChar: oldChar, newChar: newChar);

	public string Replace(string oldValue, string newValue) => WeakString.Replace(oldValue: oldValue, newValue: newValue);

	public string[] Split(char[] separator, int count) => WeakString.Split(separator: separator, count: count);

	public string[] Split(char[] separator, int count, StringSplitOptions options) => WeakString.Split(separator: separator, count: count, options: options);

	public string[] Split(char[] separator, StringSplitOptions options) => WeakString.Split(separator: separator, options: options);

	public string[] Split(params char[] separator) => WeakString.Split(separator: separator);

	public string[] Split(string[] separator, int count, StringSplitOptions options) => WeakString.Split(separator: separator, count: count, options: options);

	public string[] Split(string[] separator, StringSplitOptions options) => WeakString.Split(separator: separator, options: options);

	public bool StartsWith(string value) => WeakString.StartsWith(value: value);

	public bool StartsWith(string value, bool ignoreCase, CultureInfo culture) => WeakString.StartsWith(value: value, ignoreCase: ignoreCase, culture: culture);

	public bool StartsWith(string value, StringComparison comparisonType) => WeakString.StartsWith(value: value, comparisonType: comparisonType);

	public string Substring(int startIndex) => WeakString[startIndex..];

	public string Substring(int startIndex, int length) => WeakString.Substring(startIndex: startIndex, length: length);

	public char[] ToCharArray(int startIndex, int length) => WeakString.ToCharArray(startIndex: startIndex, length: length);

	public string ToLower() => WeakString.ToLower();

	public string ToLower(CultureInfo culture) => WeakString.ToLower(culture: culture);

	public string ToLowerInvariant() => WeakString.ToLowerInvariant();

	public sealed override string ToString() => WeakString;

	public string ToString(IFormatProvider provider) => WeakString.ToString(provider: provider);

	public string ToUpper() => WeakString.ToUpper();

	public string ToUpper(CultureInfo culture) => WeakString.ToUpper(culture: culture);

	public string ToUpperInvariant() => WeakString.ToUpperInvariant();

	public string Trim() => WeakString.Trim();

	public string Trim(params char[] trimChars) => WeakString.Trim(trimChars: trimChars);

	public string TrimEnd(params char[] trimChars) => WeakString.TrimEnd(trimChars: trimChars);

	public string TrimStart(params char[] trimChars) => WeakString.TrimStart(trimChars: trimChars);

	public int CompareTo(ISemanticString? other) => WeakString.CompareTo(strB: other?.WeakString);

	IEnumerator<char> IEnumerable<char>.GetEnumerator() => ((IEnumerable<char>)WeakString).GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)WeakString).GetEnumerator();

	public bool Contains(string value, StringComparison comparisonType) => WeakString.Contains(value: value, comparisonType: comparisonType);

	// SemanticString implementation
	[ExcludeFromCodeCoverage(Justification = "DebuggerDisplay")]
	protected string GetDebuggerDisplay() => $"({GetType().Name})\"{ToString()}\"";

	public static string ToString(SemanticString? semanticString) => semanticString?.WeakString ?? string.Empty;
	public static char[] ToCharArray(SemanticString? semanticString) => semanticString?.WeakString.ToCharArray() ?? [];
	public static ReadOnlySpan<char> ToReadOnlySpan(SemanticString? semanticString) => semanticString is null ? [] : semanticString.WeakString.AsSpan();

	public bool IsEmpty() => IsEmpty(semanticString: this);

	private static bool IsEmpty(ISemanticString? semanticString) => semanticString?.Length == 0;

	public virtual bool IsValid() => IsValid(semanticString: this);

	private static bool IsValid(ISemanticString? semanticString) => semanticString?.WeakString is not null;

	// IComparable implementation
	public static bool operator <(SemanticString? left, SemanticString? right) => left is null ? right is not null : left.CompareTo(value: (string)right) < 0;
	public static bool operator <=(SemanticString? left, SemanticString? right) => left is null || left.CompareTo(value: (string)right) <= 0;
	public static bool operator >(SemanticString? left, SemanticString? right) => left is not null && left.CompareTo(value: (string)right) > 0;
	public static bool operator >=(SemanticString? left, SemanticString? right) => left is null ? right is null : left.CompareTo(value: (string)right) >= 0;
	public static implicit operator char[](SemanticString? value) => value?.ToCharArray() ?? [];
	public static implicit operator ReadOnlySpan<char>(SemanticString? value) => value?.ToCharArray() ?? [];
	public static implicit operator string(SemanticString? value) => value?.ToString() ?? string.Empty;

	public static TDest FromCharArray<TDest>(char[]? value)
		where TDest : SemanticString
	{
		ArgumentNullException.ThrowIfNull(value);

		return FromString<TDest>(value: new string(value: value));
	}

	public static TDest FromReadOnlySpan<TDest>(ReadOnlySpan<char> value)
		where TDest : SemanticString
		=> FromString<TDest>(value: value.ToString());

	public static TDest FromString<TDest>(string? value)
		where TDest : SemanticString
	{
		var newInstance = FromStringInternal<TDest>(value: value);
		return PerformValidation(value: newInstance);
	}

	private static TDest FromStringInternal<TDest>(string? value)
		where TDest : SemanticString
	{
		ArgumentNullException.ThrowIfNull(value);

		var typeOfTDest = typeof(TDest);
		var newInstance = (TDest)Activator.CreateInstance(type: typeOfTDest)!;
		typeOfTDest.GetProperty(name: nameof(WeakString))!.SetValue(obj: newInstance, value: newInstance.MakeCanonical(value));
		return newInstance;
	}

	private static TDest PerformValidation<TDest>(TDest? value)
		where TDest : SemanticString
	{
		return value != null && value.IsValid()
			? value
			: throw new FormatException(message: $"Cannot convert \"{value}\" to {typeof(TDest).Name}");
	}

	protected static bool Validate<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>(SemanticString? value)
		where TValidator1 : ISemanticStringValidator
		where TValidator2 : ISemanticStringValidator
		where TValidator3 : ISemanticStringValidator
		where TValidator4 : ISemanticStringValidator
		where TValidator5 : ISemanticStringValidator
			=> value is not null
			&& IsValid(value)
			&& TValidator1.IsValid(value)
			&& TValidator2.IsValid(value)
			&& TValidator3.IsValid(value)
			&& TValidator4.IsValid(value)
			&& TValidator5.IsValid(value);
}

[SuppressMessage(category: "Usage", checkId: "CA2225:Operator overloads have named alternates", Justification = "The base class already has these")]
public abstract record SemanticString<TDerived> : SemanticString
	where TDerived : SemanticString<TDerived>
{
	public static explicit operator SemanticString<TDerived>(char[]? value) => FromCharArray<TDerived>(value: value);

	public static explicit operator SemanticString<TDerived>(string? value) => FromString<TDerived>(value: value);

	public TDerived WithPrefix(string prefix) => (TDerived)$"{prefix}{this}";
	public TDerived WithSuffix(string suffix) => (TDerived)$"{this}{suffix}";

	protected override string MakeCanonical(string input)
		=> base.MakeCanonical(input);
}

public abstract record SemanticString<TDerived, TValidator> : SemanticString<TDerived>
	where TDerived : SemanticString<TDerived, TValidator>
	where TValidator : ISemanticStringValidator
{
	public override bool IsValid() => base.IsValid() && Validate<TValidator, NoValidator, NoValidator, NoValidator, NoValidator>(value: this);
}

public abstract record SemanticString<TDerived, TValidator1, TValidator2> : SemanticString<TDerived>
	where TDerived : SemanticString<TDerived, TValidator1, TValidator2>
	where TValidator1 : ISemanticStringValidator
	where TValidator2 : ISemanticStringValidator
{
	public override bool IsValid() => base.IsValid() && Validate<TValidator1, TValidator2, NoValidator, NoValidator, NoValidator>(value: this);
}

public abstract record SemanticString<TDerived, TValidator1, TValidator2, TValidator3> : SemanticString<TDerived>
	where TDerived : SemanticString<TDerived, TValidator1, TValidator2, TValidator3>
	where TValidator1 : ISemanticStringValidator
	where TValidator2 : ISemanticStringValidator
	where TValidator3 : ISemanticStringValidator
{
	public override bool IsValid() => base.IsValid() && Validate<TValidator1, TValidator2, TValidator3, NoValidator, NoValidator>(value: this);
}

public abstract record SemanticString<TDerived, TValidator1, TValidator2, TValidator3, TValidator4> : SemanticString<TDerived>
	where TDerived : SemanticString<TDerived, TValidator1, TValidator2, TValidator3, TValidator4>
	where TValidator1 : ISemanticStringValidator
	where TValidator2 : ISemanticStringValidator
	where TValidator3 : ISemanticStringValidator
	where TValidator4 : ISemanticStringValidator
{
	public override bool IsValid() => base.IsValid() && Validate<TValidator1, TValidator2, TValidator3, TValidator4, NoValidator>(value: this);
}

public abstract record SemanticString<TDerived, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5> : SemanticString<TDerived>
	where TDerived : SemanticString<TDerived, TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>
	where TValidator1 : ISemanticStringValidator
	where TValidator2 : ISemanticStringValidator
	where TValidator3 : ISemanticStringValidator
	where TValidator4 : ISemanticStringValidator
	where TValidator5 : ISemanticStringValidator
{
	public override bool IsValid() => base.IsValid() && Validate<TValidator1, TValidator2, TValidator3, TValidator4, TValidator5>(value: this);
}
