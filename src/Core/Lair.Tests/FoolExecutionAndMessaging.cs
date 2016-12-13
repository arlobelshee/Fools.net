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
				var sentMessage = new SimpleTestMessage();
				SimpleTestMessage receivedMessage = null;
				await fool.DoWork(sentMessage, msg => { receivedMessage = msg; });
				receivedMessage.ShouldBeEquivalentTo(sentMessage);
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
				var timeout = Task.Delay(200.Milliseconds())
					.ContinueWith(t => Work.TimedOut);
				var result = await await Task.WhenAny(done, timeout);
				result.Should()
					.Be(Work.TimedOut);
			}
		}
	}

	public enum Work
	{
		Completed,
		TimedOut
	}
}
