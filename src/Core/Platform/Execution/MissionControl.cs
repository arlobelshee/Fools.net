using System;
using System.Threading;
using System.Threading.Tasks;

namespace Platform.Execution
{
	public class MissionControl : IDisposable
	{
		public Fool SpawnFool()
		{
			return new Fool(_taskFactory.StartNew(() => { }, _cancel.Token), _cancel.Token);
		}

		public void Dispose()
		{
			_cancel.Cancel();
			_cancel.Dispose();
		}

		private readonly CancellationTokenSource _cancel = new CancellationTokenSource();

		private readonly TaskFactory _taskFactory = new TaskFactory(TaskCreationOptions.PreferFairness, TaskContinuationOptions.LazyCancellation | TaskContinuationOptions.PreferFairness);
	}
}