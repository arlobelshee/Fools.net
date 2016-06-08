using System.Collections.Generic;

namespace Gibberish.AST._1_Bare
{
	public class CommentDefinitionBlockStatement : LanguageConstruct
	{
		public int IndentationDepth { get; }
		public string Content { get; }

		public CommentDefinitionBlockStatement(int indentationDepth, string content, IEnumerable<ParseError> errors) : base(errors)
		{
			IndentationDepth = indentationDepth;
			Content = content;
		}
	}
}