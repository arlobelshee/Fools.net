using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace test_runner
{
	public class TestRunHistoryDesignData
	{
		public TestRunHistoryDesignData()
		{
			var secondRun = new TestRun();
			secondRun.problems.Add(new TestResult(new TestContext("first_should_fail"))
			{
				result = TestResult.Code.Failed,
				message = "Expected 3 but was 9",
				duration = TimeSpan.FromMilliseconds(22)
			});
			var firstRun = new TestRun {when_run = DateTimeOffset.Now.AddMinutes(-12)};
			firstRun.successes.Add(new TestResult(new TestContext("first_should_pass"))
			{
				duration = TimeSpan.FromMilliseconds(29)
			});
			history = new List<TestRun> {secondRun, firstRun};
		}

		[NotNull]
		public IEnumerable<TestRun> history { get; private set; }
	}

	public class TestRun
	{
		public DateTimeOffset when_run { get; set; } = DateTimeOffset.Now;
		public TimeSpan duration { get; set; } = TimeSpan.Zero;

		[NotNull]
		public List<TestResult> problems { get; } = new List<TestResult>();

		[NotNull]
		public List<TestResult> inconclusives { get; } = new List<TestResult>();

		[NotNull]
		public List<TestResult> successes { get; } = new List<TestResult>();
	}

	public class TestResult
	{
		public enum Code
		{
			Success,
			Error,
			Failed,
			Ignored,
			PartiallyIgnored
		}

		public TestResult(TestContext whichTest)
		{
			which_test = whichTest;
		}

		public TimeSpan duration { get; set; } = TimeSpan.Zero;
		public Code result { get; set; } = Code.Success;

		[CanBeNull]
		public Exception captured_exception { get; set; } = null;

		[NotNull]
		public string captured_output { get; set; } = string.Empty;

		[NotNull]
		public string message { get; set; } = string.Empty;

		[NotNull]
		public Dictionary<string, string> useful_data { get; } = new Dictionary<string, string>();

		[NotNull]
		public TestContext which_test { get; }
	}

	public class TestContext
	{
		public TestContext(string name)
		{
			Name = name;
		}

		public string Name { get; set; }
	}
}