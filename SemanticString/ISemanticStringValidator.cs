// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

#pragma warning disable CS1591

namespace ktsu.Semantics;

public interface ISemanticStringValidator
{
	public static abstract bool IsValid(ISemanticString? semanticString);
}

public abstract record NoValidator : ISemanticStringValidator
{
	public static bool IsValid(ISemanticString? semanticString) => true;
}
