﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Gibberish.AST;
using Gibberish.AST._1_Bare;
using JetBrains.Annotations;

namespace Gibberish.Parsing
{
	partial class RecognizeBlocks
	{
		[NotNull]
		public IEnumerable<LanguageConstruct> ParseWholeFile([NotNull] string input)
		{
			return ParseWholeFileNewImpl(input);
		}

		[NotNull]
		private IEnumerable<LanguageConstruct> ParseWholeFileNewImpl([NotNull] string input)
		{
			var hasNewlineatEndOfFile = false;
			if (input.EndsWith(CRLF))
			{
				hasNewlineatEndOfFile = true;
				input = input.Substring(0, input.Length - 2);
			}
			else if (input.EndsWith(LF) || input.EndsWith(CR))
			{
				hasNewlineatEndOfFile = true;
				input = input.Substring(0, input.Length - 1);
			}
			var result = input.Split(
				new[]
				{
					CRLF,
					LF,
					CR
				},
				StringSplitOptions.None)
				.Select(_InterpretLine)
				.Where(_ => _ != null)
				.ToList();
			if (!hasNewlineatEndOfFile) { result[result.Count - 1].Errors.Add(ParseError.MissingNewlineAtEndOfFile()); }
			return result;
		}

		[NotNull]
		private LanguageConstruct _InterpretLine([NotNull] string line)
		{
			var content = line.TrimStart('\t');
			var indentationDepth = line.Length - content.Length;
			if (string.IsNullOrWhiteSpace(content)) { return _ExtractBlankLine(indentationDepth, content, CRLF); }
			if (content.StartsWith("##"))
			{
				inCommentSection = true;
				var match = _commentDefinitionBlockPreludePattern.Match(content);
				if (!match.Success) { return _ExtractCommentDefinitionBlockPrelude(indentationDepth, "", ""); }
				var commentId = match.Groups["commentId"].Value;
				var extra = match.Groups["extra"].Value;
				return _ExtractCommentDefinitionBlockPrelude(indentationDepth, commentId, extra); 
			}
			if (content.StartsWith("#"))
			{
				inCommentSection = true;
				var match = _CommentDefinitionPattern.Match(content);
				if (!match.Success) { return _ExtractSingleLineCommentDefinition("", content.Substring(1).TrimStart(), "", CRLF); }
				var commentId = match.Groups["commentId"].Value;
				var commentSeparator = match.Groups["commentSeparator"].Value;
				var firstLineContent = match.Groups["firstLineContent"].Value;

				return _ExtractSingleLineCommentDefinition(commentId, firstLineContent, commentSeparator, CRLF);
			}
			if (inCommentSection)
			{
				return _ExtractMultiLineCommentStatement(indentationDepth, content);
			}

			if (content.Contains(":"))
			{
				var parts = content.Split(
					new[]
					{
						':'
					},
					2);
				return _ExtractPreludeAndErrors(indentationDepth, parts[0], parts[1], CRLF);
			}
			return _ExtractStatementAndErrors(indentationDepth, content, CRLF);
		}

		bool inCommentSection = false;

		private readonly Regex _commentDefinitionBlockPreludePattern = new Regex(@"(?x)
				^\#\#
					\[(?<commentId>[0-9]+)\]\:(?<extra>.*)
", RegexOptions.Compiled);

		private readonly Regex _CommentDefinitionPattern = new Regex(@"(?x)^\#
				\[(?<commentId>[0-9]+)\]\:
				(?<commentSeparator>\s+)
				(?<firstLineContent>.*)
", RegexOptions.Compiled);

		//private LanguageConstruct _ExtractMultiLineCommentDefinition()
		//{
		//	var commentEnd = _commentProgress.Last();
		//	_commentProgress.RemoveAt(_commentProgress.Count - 1);
		//	var match = _CommentDefinitionPattern.Match(_commentProgress[0]);
		//	if (!match.Success) { return _ExtractMultiLineCommentDefinition("", _commentProgress[0], "", commentEnd); }
		//	var commentId = match.Groups["commentId"].Value;
		//	var commentSeparator = match.Groups["commentSeparator"].Value;
		//	var firstLineContent = match.Groups["firstLineContent"].Value;
		//	_commentProgress[0] = firstLineContent;
		//	var content = string.Join(Environment.NewLine, _commentProgress) + Environment.NewLine;

		//	return _ExtractMultiLineCommentDefinition(commentId, content, commentSeparator, commentEnd);
		//}

		//private readonly List<string> _commentProgress = new List<string>();

		//private LanguageConstruct _SaveProgress(string line)
		//{
		//	_commentProgress.Add(line);
		//	return null;
		//}

		private const string CRLF = CR + LF;
		private const string CR = "\r";
		private const string LF = "\n";
	}
}
