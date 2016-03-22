using System.Collections.Generic;
using JetBrains.Annotations;

namespace Gibberish.AST._1_Bare
{
	public static class BasicAst
	{
		public static StatementBuilder Statement([NotNull] string content)
		{
			return new StatementBuilder(content);
		}

		public class StatementBuilder : Builder
		{
			public StatementBuilder(string content)
			{
				Content = content;
			}

			[NotNull]
			public string Content { get; set; }
			[NotNull]
			public IEnumerable<ParseError> Errors { get; set; } = Recognition.NoErrors;

			internal override void Build(List<BareStatement> list)
			{
				list.Add(new BareStatement(Content, Errors));
			}
		}

		public abstract class Builder
		{
			[NotNull]
			public List<BareStatement> Build()
			{
				var statements = new List<BareStatement>();
				Build(statements);
				return statements;
			}

			internal abstract void Build([NotNull] List<BareStatement> list);
		}
	}
}
