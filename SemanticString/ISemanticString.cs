#pragma warning disable CS1591

namespace ktsu.Semantics;

using System.Globalization;
using System.Text;

public interface ISemanticString : IComparable, IComparable<ISemanticString>, IEnumerable<char>
{
	string WeakString { get; init; }

	// System.String interface
	char this[int index] { get; }

	int Length { get; }

	//object Clone(); // REMOVED: we'll be using records, which are immutable, so can't be cloned
	new int CompareTo(object value);

	//int CompareTo(string strB); // REMOVED: this conflicts with IComparable<ISemanticString>.CompareTo which can implicitly convert to string anyway
	bool Contains(string value);
	bool Contains(string value, StringComparison comparisonType);
	void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count);
	bool EndsWith(string value);
	bool EndsWith(string value, bool ignoreCase, CultureInfo culture);
	bool EndsWith(string value, StringComparison comparisonType);
	bool Equals(object obj);
	bool Equals(string value);
	bool Equals(string value, StringComparison comparisonType);
	new CharEnumerator GetEnumerator();
	int GetHashCode();
	TypeCode GetTypeCode();
	int IndexOf(char value);
	int IndexOf(char value, int startIndex);
	int IndexOf(char value, int startIndex, int count);
	int IndexOf(string value);
	int IndexOf(string value, int startIndex);
	int IndexOf(string value, int startIndex, int count);
	int IndexOf(string value, int startIndex, int count, StringComparison comparisonType);
	int IndexOf(string value, int startIndex, StringComparison comparisonType);
	int IndexOf(string value, StringComparison comparisonType);
	int IndexOfAny(char[] anyOf);
	int IndexOfAny(char[] anyOf, int startIndex);
	int IndexOfAny(char[] anyOf, int startIndex, int count);
	string Insert(int startIndex, string value);
	bool IsNormalized();
	bool IsNormalized(NormalizationForm normalizationForm);
	int LastIndexOf(char value);
	int LastIndexOf(char value, int startIndex);
	int LastIndexOf(char value, int startIndex, int count);
	int LastIndexOf(string value);
	int LastIndexOf(string value, int startIndex);
	int LastIndexOf(string value, int startIndex, int count);
	int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType);
	int LastIndexOf(string value, int startIndex, StringComparison comparisonType);
	int LastIndexOf(string value, StringComparison comparisonType);
	int LastIndexOfAny(char[] anyOf);
	int LastIndexOfAny(char[] anyOf, int startIndex);
	int LastIndexOfAny(char[] anyOf, int startIndex, int count);
	string Normalize();
	string Normalize(NormalizationForm normalizationForm);
	string PadLeft(int totalWidth);
	string PadLeft(int totalWidth, char paddingChar);
	string PadRight(int totalWidth);
	string PadRight(int totalWidth, char paddingChar);
	string Remove(int startIndex);
	string Remove(int startIndex, int count);
	string Replace(char oldChar, char newChar);
	string Replace(string oldValue, string newValue);
	string[] Split(char[] separator, int count);
	string[] Split(char[] separator, int count, StringSplitOptions options);
	string[] Split(char[] separator, StringSplitOptions options);
	string[] Split(params char[] separator);
	string[] Split(string[] separator, int count, StringSplitOptions options);
	string[] Split(string[] separator, StringSplitOptions options);
	bool StartsWith(string value);
	bool StartsWith(string value, bool ignoreCase, CultureInfo culture);
	bool StartsWith(string value, StringComparison comparisonType);
	string Substring(int startIndex);
	string Substring(int startIndex, int length);
	char[] ToCharArray();
	char[] ToCharArray(int startIndex, int length);
	string ToLower();
	string ToLower(CultureInfo culture);
	string ToLowerInvariant();
	string ToString();
	string ToString(IFormatProvider provider);
	string ToUpper();
	string ToUpper(CultureInfo culture);
	string ToUpperInvariant();
	string Trim();
	string Trim(params char[] trimChars);
	string TrimEnd(params char[] trimChars);
	string TrimStart(params char[] trimChars);
}
