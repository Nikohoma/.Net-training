using System; // String
using System.Threading.Tasks; // Task
using NUnit.Framework.Legacy; // NUnit

namespace ItTechGenie.M1.NUnit.Q7
{
    public static class AsyncProcessor
    {
        // ✅ TODO: Student must implement only this method
        public static async Task<string> GetFinalStatusAsync(string[] events, int delayMs)
        {
            // TODO:
            // - validate events not null
            // - await Task.Delay(delayMs) for each event (simulate IO)
            // - detect type before first '|'
            // - if any type == "Delivered" => return "Delivered"
            // - else return "InProgress"
            if(events == null) { throw new Exception("Events are empty"); }
            foreach(var e in events) { await Task.Delay(delayMs); }

            var last = events[events.Length - 1];
            if (last.Contains("Delivered")) { return "Delivered"; }
            else { return "InProgress"; }
        }
    }

    [TestFixture]
    public class AsyncProcessorTests
    {
        [Test]
        public async Task GetFinalStatusAsync_Should_ReturnDelivered_WhenDeliveredEventExists()
        {
            var events = new[]
            {
                "PickedUp|2026-02-17 10:05|Agent: R@hul",
                "InTransit|2026-02-17 21:45|Hub#02 (BLR)",
                "Delivered|2026-02-18 09:20|Agent: Priya ✅"
            };

            var status = await AsyncProcessor.GetFinalStatusAsync(events, delayMs: 1);

            ClassicAssert.AreEqual("Delivered", status);
        }
    }
}