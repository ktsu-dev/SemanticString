# ktsu.SemanticString

> A transparent wrapper for strings providing strong typing, compile-time feedback, and runtime validation

[![License](https://img.shields.io/github/license/ktsu-dev/SemanticString)](https://github.com/ktsu-dev/SemanticString/blob/main/LICENSE.md)
[![NuGet](https://img.shields.io/nuget/v/ktsu.SemanticString.svg)](https://www.nuget.org/packages/ktsu.SemanticString/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/ktsu.SemanticString.svg)](https://www.nuget.org/packages/ktsu.SemanticString/)
[![Build Status](https://github.com/ktsu-dev/SemanticString/workflows/build/badge.svg)](https://github.com/ktsu-dev/SemanticString/actions)
[![GitHub Stars](https://img.shields.io/github/stars/ktsu-dev/SemanticString?style=social)](https://github.com/ktsu-dev/SemanticString/stargazers)

## Introduction

SemanticString provides a transparent wrapper around system strings to give you strong typing, compile time feedback, and runtime validation. It allows you to provide usage context and validation to naked strings in a similar way that Enums do for integers, making your code more type-safe and self-documenting.

## Features

- **Strong Typing**: Create domain-specific string types to prevent type confusion
- **Compile-time Safety**: Catch type mismatches at compile time rather than runtime
- **Runtime Validation**: Add custom validation rules to ensure strings meet your requirements
- **Seamless Integration**: Works naturally with existing string methods and APIs
- **Zero-overhead**: Designed for minimal performance impact when using validated strings

## Installation

### Package Manager Console

```powershell
Install-Package ktsu.SemanticString
```

### .NET CLI

```bash
dotnet add package ktsu.SemanticString
```

### Package Reference

```xml
<PackageReference Include="ktsu.SemanticString" Version="x.y.z" />
```

## Usage Examples

### Basic Example

```csharp
using ktsu.Semantics;

// Create a strong type by deriving a record class from SemanticString<TDerived>:
public record class MyStrongString : SemanticString<MyStrongString> { }

// Use the strong type in your code
public void ProcessData(MyStrongString data)
{
    // Strong typing ensures you can't pass just any string here
    Console.WriteLine(data);
}

// Create an instance
MyStrongString strongString = (MyStrongString)"Hello world";
```

### Type Conversions

```csharp
public class MyDemoClass
{
    public MyStrongString Stronk { get; set; } = new();

    public static void Demo(MyStrongString inStrongString, string inSystemString, out MyStrongString outStrongString, out string outSystemString)
    {
        // You can implicitly cast down to a System.String
        outSystemString = inStrongString;

        // You must explicitly cast up to a StrongString
        outStrongString = (MyStrongString)inSystemString;

        // You can provide a StrongString to a method that expects a System.String
        Path.Combine(inStrongString, inSystemString);

        // You can use the .WeakString property or .ToString() method to get the underlying System.String
        outSystemString = inStrongString.WeakString;
        outSystemString = inStrongString.ToString();
    }
}
```

## Advanced Usage

### Custom Validation

You can provide custom validators which will throw a `FormatException` at runtime to help you catch data errors:

```csharp
// Create validator classes by implementing ISemanticStringValidator
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

// Apply multiple validators to a semantic string type
public record class MyValidatedString : SemanticString<MyValidatedString, StartsWithHttp, EndsWithDotCom> { }

// This will pass validation
MyValidatedString valid = (MyValidatedString)"http://example.com";

// This will throw a FormatException
MyValidatedString invalid = (MyValidatedString)"example.org"; // Throws exception: doesn't end with .com
```

### Complex Validation

For more complex validation scenarios, you can combine multiple validators:

```csharp
// Email validator
public abstract class EmailValidator : ISemanticStringValidator
{
    public static bool IsValid(SemanticString? semanticString)
    {
        ArgumentNullException.ThrowIfNull(semanticString);
        
        try
        {
            var addr = new System.Net.Mail.MailAddress(semanticString);
            return addr.Address == semanticString;
        }
        catch
        {
            return false;
        }
    }
}

public record class EmailAddress : SemanticString<EmailAddress, EmailValidator> { }
```

## Migration from StrongStrings

SemanticString is the successor to StrongStrings and provides improved functionality while maintaining compatibility with StrongStrings' core features. This section provides guidance for migrating from StrongStrings to SemanticString.

### Key Differences and Improvements

1. **Namespace Change**: SemanticString uses `ktsu.Semantics` namespace instead of `ktsu.StrongStrings`.
2. **Validator Approach**: SemanticString supports both:
   - Interface-based validation (`ISemanticStringValidator`)
   - Attribute-based validation (same as StrongStrings)
3. **Modern Features**: SemanticString adds support for `ReadOnlySpan<char>` and other modern C# features.

### Migration Options

#### Option 1: Direct Replacement

Update your class definitions to use SemanticString instead of StrongString:

```csharp
// Old (StrongStrings)
using ktsu.StrongStrings;

public record MyString : StrongString<MyString> { }

// New (SemanticString)
using ktsu.Semantics;

public record MyString : SemanticString<MyString> { }
```

#### Option 2: Using the Compatibility Layer

The compatibility layer provides aliases to make migration easier:

```csharp
// Use the aliases namespace for a smooth transition
using ktsu.StrongStrings.Aliases;

// This class is actually using SemanticString under the hood, but with
// StrongString compatible naming
public record MyString : StrongString<MyString> { }
```

### Migrating Attribute Validation

SemanticString fully supports the attribute-based validation pattern from StrongStrings:

```csharp
// Attribute-based validation works the same way in SemanticString
[StartsWith("http://")]
[EndsWith(".com")]
public record MyUrl : SemanticString<MyUrl> { }
```

All validation attributes from StrongStrings have been ported:
- `[StartsWith]`, `[EndsWith]`, `[Contains]`
- `[RegexMatch]`, `[PrefixAndSuffix]`
- `[ValidateAll]`, `[ValidateAny]` for logical combinations

### Interface-Based Validation

In addition to attribute-based validation, SemanticString also supports interface-based validators:

```csharp
// Define a validator
public abstract class HttpValidator : ISemanticStringValidator
{
    public static bool IsValid(ISemanticString? semanticString)
    {
        return semanticString?.StartsWith("http", StringComparison.OrdinalIgnoreCase) ?? false;
    }
}

// Use the validator with generics
public record MyUrl : SemanticString<MyUrl, HttpValidator> { }
```

## API Reference

### `SemanticString<TDerived>` Class

Base class for creating semantic string types without validation.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `WeakString` | `string` | The underlying string value |

#### Methods

| Name | Return Type | Description |
|------|-------------|-------------|
| `ToString()` | `string` | Returns the underlying string value |
| `Equals(object?)` | `bool` | Determines whether the specified object is equal to the current object |
| `GetHashCode()` | `int` | Returns the hash code for this instance |
| `TryParse(string?, out TDerived?)` | `bool` | Attempts to parse a string into a SemanticString of type TDerived |

### `SemanticString<TDerived, TValidator1, ...>` Class

Base class for creating semantic string types with one or more validators.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
