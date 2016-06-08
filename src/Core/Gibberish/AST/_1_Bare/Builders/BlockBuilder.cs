using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Gibberish.AST._1_Bare.Builders
{
	public class BlockBuilder : BlockBuilderBase<BlockBuilder, BlockBuilder.PreludeBuilder, BlockBuilder.BodyBuilder>
	{
		public BlockBuilder([NotNull] string prelude, [NotNull] Action<PreludeBuilder> preludeOptions) : base(preludeOptions, new PreludeBuilder(prelude)) {}

		public bool StartsParagraph { get; private set; }

		public class PreludeBuilder : PreludeBuilderBase
		{
			public PreludeBuilder([NotNull] string content) : base(content) {}

			public override void BuildInto(List<LanguageConstruct> destination)
			{
				destination.Add(new UnknownPrelude(PossiblySpecified<int>.Unspecifed, Content, Comments, Errors));
			}
		}

		public class BodyBuilder : BodyBuilderBase
		{
			public BodyBuilder([NotNull] BlockBuilder self) : base(self) {}

			public override PossiblySpecified<int> IndentationDepth => PossiblySpecified<int>.Unspecifed;

			protected override BlockBuilder CreateBlockBuilder(string prelude, Action<PreludeBuilder> preludeOptions)
			{
				return new BlockBuilder(prelude, preludeOptions);
			}
		}

		public override void BuildInto(List<LanguageConstruct> destination)
		{
			var prelude = new List<LanguageConstruct>();
			Prelude.BuildInto(prelude);
			var bodyConstructs = new List<LanguageConstruct>();
			_BuildBodyInto(bodyConstructs);
			destination.Add(
				new UnknownBlock(
					StartsParagraph,
					prelude.Cast<UnknownPrelude>()
						.Single(),
					bodyConstructs,
					Errors));
		}

		public BlockBuilder ThatStartsNewParagraph()
		{
			StartsParagraph = true;
			return this;
		}

		protected override BodyBuilder CreateBodyBuilder()
		{
			return new BodyBuilder(this);
		}
	}
}
