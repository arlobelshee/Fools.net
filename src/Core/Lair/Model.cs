﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gibberish.AST._1_Bare;
using Gibberish.Parsing;
using ICSharpCode.AvalonEdit.Document;
using JetBrains.Annotations;

namespace Lair
{
	public class Model
	{
		public Model([NotNull] Func<string, string> formatter, [CanBeNull] IDocumentStore documentStore)
		{
			_pipelineStart = LanguageTools.Pipeline()
				.WithResultListener(_HandleResults)
				.Build();
			_formatter = formatter;
			_documentStore = documentStore;
			ViewModel = new MainViewModel
			{
				FormatAll = {
					On = AutoformatCurrentCode
				},
				Open = {
					On = ReplaceCurrentCodeWithFileContents
				},
				Save = {
					On = SaveCurrentCodeToFile
				},
				CodeChanged = {
					On = UpdateErrors
				}
			};
		}

		public MainViewModel ViewModel { get; }

		public async Task SaveCurrentCodeToFile()
		{
			_currentDocument.Contents = ViewModel.Code.Text;
			if (_documentStore != null) await _documentStore.Save(_currentDocument);
		}

		public async Task ReplaceCurrentCodeWithFileContents()
		{
			if (_documentStore == null) { return; }
			_currentDocument = await _documentStore.Open();
			ViewModel.Code = new TextDocument(_currentDocument.Contents);
		}

		public async Task AutoformatCurrentCode()
		{
			ViewModel.Code.Text = _formatter(ViewModel.Code.Text);
		}

		private async Task UpdateErrors()
		{
			try
			{
				if (ViewModel.Code != null) _pipelineStart.Analyze(ViewModel.Code.Text);
			}
			catch (Exception ex) {
				ViewModel.Errors = $"Unhandled exception crashed the parser!\r\n\r\n{ex}";
			}
		}

		private void _HandleResults(List<LanguageConstruct> results)
		{
			var errors = new ErrorFinder();
			results.ForEach(block => block.Accept(errors));
			ViewModel.Errors = errors.Errors.Count > 0 ? string.Join("\r\n\r\n", errors.Errors) : "You're all good, boss!";
		}

		[CanBeNull] private readonly IDocumentStore _documentStore;
		[NotNull] private readonly Func<string, string> _formatter;
		[NotNull] private readonly LanguagePipelineStart _pipelineStart;
		[NotNull] private IDocument _currentDocument = new InitiallyEmptyDocument();
	}
}
