#pragma warning disable CS1591

namespace ktsu.Semantics;

using System.Globalization;
using System.Text;

public interface ISemanticString : IComparable, IComparable<ISemanticString>, IEnumerable<char>
{
	public string WeakString { get; init; }

	// System.String interface
	public char this[int index] { get; }

	public int Length { get; }

	//object Clone(); // REMOVED: we'll be using records, which are immutable, so can't be cloned
	public new int CompareTo(object value);

	//int CompareTo(string strB); // REMOVED: this conflicts with IComparable<ISemanticString>.CompareTo which can implicitly convert to string anyway
	public bool Contains(string value);
	public bool Contains(string value, StringComparison comparisonType);
	public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count);
	public bool EndsWith(string value);
	public bool EndsWith(string value, bool ignoreCase, CultureInfo culture);
	public bool EndsWith(string value, StringComparison comparisonType);
	public bool Equals(object obj);
	public bool Equals(string value);
	public bool Equals(string value, StringComparison comparisonType);
	public new CharEnumerator GetEnumerator();
	public int GetHashCode();
	public TypeCode GetTypeCode();
	public int IndexOf(char value);
	public int IndexOf(char value, int startIndex);
	public int IndexOf(char value, int startIndex, int count);
	public int IndexOf(string value);
	public int IndexOf(string value, int startIndex);
	public int IndexOf(string value, int startIndex, int count);
	public int IndexOf(string value, int startIndex, int count, StringComparison comparisonType);
	public int IndexOf(string value, int startIndex, StringComparison comparisonType);
	public int IndexOf(string value, StringComparison comparisonType);
	public int IndexOfAny(char[] anyOf);
	public int IndexOfAny(char[] anyOf, int startIndex);
	public int IndexOfAny(char[] anyOf, int startIndex, int count);
	public string Insert(int startIndex, string value);
	public bool IsNormalized();
	public bool IsNormalized(NormalizationForm normalizationForm);
	public int LastIndexOf(char value);
	public int LastIndexOf(char value, int startIndex);
	public int LastIndexOf(char value, int startIndex, int count);
	public int LastIndexOf(string value);
	public int LastIndexOf(string value, int startIndex);
	public int LastIndexOf(string value, int startIndex, int count);
	public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType);
	public int LastIndexOf(string value, int startIndex, StringComparison comparisonType);
	public int LastIndexOf(string value, StringComparison comparisonType);
	public int LastIndexOfAny(char[] anyOf);
	public int LastIndexOfAny(char[] anyOf, int startIndex);
	public int LastIndexOfAny(char[] anyOf, int startIndex, int count);
	public string Normalize();
	public string Normalize(NormalizationForm normalizationForm);
	public string PadLeft(int totalWidth);
	public string PadLeft(int totalWidth, char paddingChar);
	public string PadRight(int totalWidth);
	public string PadRight(int totalWidth, char paddingChar);
	public string Remove(int startIndex);
	public string Remove(int startIndex, int count);
	public string Replace(char oldChar, char newChar);
	public string Replace(string oldValue, string newValue);
	public string[] Split(char[] separator, int count);
	public string[] Split(char[] separator, int count, StringSplitOptions options);
	public string[] Split(char[] separator, StringSplitOptions options);
	public string[] Split(params char[] separator);
	public string[] Split(string[] separator, int count, StringSplitOptions options);
	public string[] Split(string[] separator, StringSplitOptions options);
	public bool StartsWith(string value);
	public bool StartsWith(string value, bool ignoreCase, CultureInfo culture);
	public bool StartsWith(string value, StringComparison comparisonType);
	public string Substring(int startIndex);
	public string Substring(int startIndex, int length);
	public char[] ToCharArray();
	public char[] ToCharArray(int startIndex, int length);
	public string ToLower();
	public string ToLower(CultureInfo culture);
	public string ToLowerInvariant();
	public string ToString();
	public string ToString(IFormatProvider provider);
	public string ToUpper();
	public string ToUpper(CultureInfo culture);
	public string ToUpperInvariant();
	public string Trim();
	public string Trim(params char[] trimChars);
	public string TrimEnd(params char[] trimChars);
	public string TrimStart(params char[] trimChars);
}
