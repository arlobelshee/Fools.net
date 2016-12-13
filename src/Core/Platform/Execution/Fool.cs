using System;
using System.Threading;
using System.Threading.Tasks;

namespace Platform.Execution
{
	public sealed class Fool
	{
		internal Fool(Task currentTask, CancellationToken cancel)
		{
			_currentTask = currentTask;
			_cancel = cancel;
		}

		public Task DoWork<T>(T message, Action<T> action) where T : class, FoolMessage
		{
			_currentTask = _currentTask.ContinueWith((_, msg) => action(msg as T), message, _cancel, TaskContinuationOptions.NotOnCanceled, TaskScheduler.Current);
			return _currentTask;
		}

		private readonly CancellationToken _cancel;

		private Task _currentTask;
	}
}