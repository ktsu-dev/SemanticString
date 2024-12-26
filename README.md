# SemanticString

A library that provides a transparent wrapper around system strings and gives you strong typing, compile time feedback, and runtime validation.

The intention is to be able to provide usage context and validation to naked strings in a similar way that Enums do for integers.

## Usage
```csharp
using ktsu.Semantics;

// Create a strong type by deriving a record class from SemanticString<TDerived>:
public record class MyStrongString : SemanticString<MyStrongString> { }

public class MyDemoClass
{
	public MyStrongString Stronk { get; set; } = new();

	public static void Demo(MyStrongString inStrongString, string inSystemString, out MyStrongString outStrongString, out string outSystemString)
	{
		// You can implicitly cast down to a System.String
		outSystemString = inStrongString;

		// You must explicitly cast up to a StrongString
		outStrongString = (MyStrongString)inSystemString;

		//You can provide a StrongString to a method that expects a System.String
		Path.Combine(inStrongString, inSystemString);

		// You can use the .WeakString property or the .ToString() method to get the value of the underlying System.String
		outSystemString = inStrongString.WeakString;
		outSystemString = inStrongString.ToString();

		// You can not implicitly cast up to a StrongString
		// outStrongString = inSystemString; // This will not compile

		// You can not cast from one StrongString to another
		// OtherStrongString other = inStrongString; // This will not compile
		// OtherStrongString other = (OtherStrongString)inStrongString; // This will not compile either
	}
}
```

## Validation
You can provide custom validators which will throw a `FormatException` at runtime to help you catch data errors.

Implement the `ktsu.Semantics.ISemanticStringValidator` interface and provide it as a generic parameter when deriving your class:

```csharp
public abstract class StartsWithHttp : ISemanticStringValidator
{
	public static bool IsValid(SemanticString? semanticString)
	{
		ArgumentNullException.ThrowIfNull(semanticString);

		return semanticString.StartsWith("http", StringComparison.InvariantCultureIgnoreCase);
	}
}

public abstract class EndsWithDotCom : ISemanticStringValidator
{
	public static bool IsValid(SemanticString? semanticString)
	{
		ArgumentNullException.ThrowIfNull(semanticString);

		return semanticString.EndsWith(".com", StringComparison.InvariantCultureIgnoreCase);
	}
}

public record class MyValidatedString : SemanticString<MyValidatedString, StartsWithHttp, EndsWithDotCom> { }
```
