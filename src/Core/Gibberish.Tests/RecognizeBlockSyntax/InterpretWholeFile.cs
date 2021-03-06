﻿using Gibberish.AST._1_Bare;
using Gibberish.Parsing;
using Gibberish.Parsing.Passes;
using Gibberish.Tests.ZzTestHelpers;
using NUnit.Framework;

namespace Gibberish.Tests.RecognizeBlockSyntax
{
	[TestFixture]
	public class InterpretWholeFile
	{
		[Test]
		public void should_accept_multiple_language_constructs()
		{
			var subject = new RecognizeLines();
			var input = @"
using language fasm

define.thunk some.name:
	pass

define.thunk other.name:
	pass
";
			var result = subject.ParseWholeFile(input);
			result.Should()
				.BeRecognizedAs(
					BasicAst.SequenceOfRawLines(
						f =>
						{
							f.BlankLine(0);
							f.Statement("using language fasm");
							f.BlankLine(0);
							f.Block("define.thunk some.name")
								.WithBody(b => b.AddStatement("pass"));
							f.BlankLine(0);
							f.Block("define.thunk other.name")
								.WithBody(b => b.AddStatement("pass"));
						}));
		}
	}
}
