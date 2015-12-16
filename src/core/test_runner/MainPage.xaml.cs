﻿using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using JetBrains.Annotations;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace test_runner
{
	public sealed partial class MainPage : Page
	{
		[NotNull] private string _parameter;

		public MainPage()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo([NotNull] NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			_parameter = ((string) e.Parameter) ?? string.Empty;
			DataContext = new TestRunHistoryDesignData();
		}
	}
}