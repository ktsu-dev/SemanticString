#pragma warning disable CS1591

namespace ktsu.Semantics;

public interface ISemanticStringValidator
{
	static abstract bool IsValid(ISemanticString? semanticString);
}

public abstract record NoValidator : ISemanticStringValidator
{
	public static bool IsValid(ISemanticString? semanticString) => true;
}
