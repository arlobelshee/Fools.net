using System;
using System.Collections.Generic;

namespace test_runner
{
	public class TestRunHistoryDesignData
	{
		public TestRunHistoryDesignData()
		{
			History = new List<TestRun> {new TestRun(), new TestRun {when_run = DateTimeOffset.Now.AddMinutes(-12)}};
		}

		public IEnumerable<TestRun> History { get; set; }
	}

	public class TestRun
	{
		public DateTimeOffset when_run { get; set; } = DateTimeOffset.Now;
	}
}