using System;
using Windows.UI.Xaml.Data;

namespace test_runner
{
	public class ShowHowLongAgo : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (targetType != typeof (string)) throw new NotImplementedException();
			return HowLongBetween(DateTimeOffset.Now, value as DateTimeOffset?);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}

		private string HowLongBetween(DateTimeOffset now, DateTimeOffset? when)
		{
			if (!when.HasValue) return "never";
			var howLongAgo = (now - when.Value).Duration();
			if (howLongAgo.TotalSeconds <= 6.0) return "just now";
			if (howLongAgo.TotalHours >= 3.0) return "hours and hours ago";
			if (howLongAgo.TotalHours > 1.0) return "more than an hour ago";
			if (howLongAgo.TotalHours > 0.5) return "half an hour ago";
			if (howLongAgo.TotalMinutes > 5.01) return string.Format("{0} minutes ago", Math.Round(howLongAgo.Minutes /5.0)*5);
			if (howLongAgo.TotalMinutes > 1.01) return string.Format("{0} minutes ago", howLongAgo.Minutes);
			return string.Format("{0} seconds ago", Math.Round(howLongAgo.Seconds/10.0)*10.0);
		}
	}
}