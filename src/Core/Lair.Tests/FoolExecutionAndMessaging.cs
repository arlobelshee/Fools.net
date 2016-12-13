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
	}
}
