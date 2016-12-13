using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Lair.Tests.zzTestSupport;
using NUnit.Framework;
using Platform.Execution;

namespace Lair.Tests
{
	[TestFixture]
	public class FoolExecutionAndMessaging
	{
		[Test]
		public async Task ExecuteWorkWhenScheduled()
		{
			using (var testSubject = new MissionControl())
			{
				var fool = testSubject.SpawnFool();
				await Send(fool, new SimpleTestMessage(), (msg, original) => { msg.ShouldBeEquivalentTo(original); });
			}
		}

		[Test]
		public async Task ExecuteTasksSequentiallyAndInOrder()
		{
			using (var testSubject = new MissionControl())
			{
				var fool = testSubject.SpawnFool();
				var sentMessage = new SimpleTestMessage();
				SimpleTestMessage receivedMessage = null;
				var barrier = new Barrier(2);
				var first = fool.DoWork(
					sentMessage,
					msg =>
					{
						barrier.SignalAndWait();
						receivedMessage = msg;
					});
				var second = fool.DoWork(sentMessage, msg => { barrier.SignalAndWait(); });
				var done = Task.WhenAll(first, second)
					.ContinueWith(
						t =>
						{
							barrier.Dispose();
							return Work.Completed;
						});
				var timeout = Task.Delay(100.Milliseconds())
					.ContinueWith(t => Work.TimedOut);
				var result = await await Task.WhenAny(done, timeout);
				result.Should()
					.Be(Work.TimedOut);
			}
		}

		private static Task Send(Fool fool, SimpleTestMessage sentMessage, Action<SimpleTestMessage, SimpleTestMessage> work)
		{
			return fool.DoWork(sentMessage, m => { work(m, sentMessage); });
		}
	}

	public enum Work
	{
		Completed,
		TimedOut
	}
}
