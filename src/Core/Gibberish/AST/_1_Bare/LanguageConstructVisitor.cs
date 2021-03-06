using System.Collections.Generic;

namespace Gibberish.AST._1_Bare
{
	public interface LanguageConstructVisitor
	{
		bool Visit(BlankLine line, int level, List<LanguageConstruct> result);

		bool Visit(UnknownStatement statement, int level, List<LanguageConstruct> result);

		bool Visit(CommentDefinition commentDefinition, int level, List<LanguageConstruct> result);

		bool Visit(UnknownPrelude prelude, int level, List<LanguageConstruct> result);

		bool Visit(UnknownBlock block, int level, List<LanguageConstruct> result);

		bool Visit(CommentDefinitionBlockPrelude prelude, int level, List<LanguageConstruct> result);

		bool Visit(CommentDefinitionBlockStatement statement, int level, List<LanguageConstruct> result);

		bool Visit(CommentDefinitionBlock commentDefinition, int level, List<LanguageConstruct> result);
	}
}
