using System; // String
using System.Collections.Generic; // IEnumerable
using NUnit.Framework.Legacy; // NUnit

namespace ItTechGenie.M1.NUnit.Q10
{
    public static class StockRuleEngine
    {
        // ✅ TODO: Student must implement only this method
        public static string Evaluate(int qty)
        {
            // TODO:
            // - qty <= 0 => "OutOfStock"
            // - qty < 5  => "LowStock"
            // - else     => "Available"
            if (qty <= 0) { return "OutOfStock"; }
            else if (qty < 5) { return "LowStock"; }
            return "Available";

        }
    }

    [TestFixture]
    public class StockRuleEngineTests
    {
        public static IEnumerable<TestCaseData> Cases()
        {
            yield return new TestCaseData(0, "OutOfStock").SetName("qty_0");
            yield return new TestCaseData(-1, "OutOfStock").SetName("qty_negative");
            yield return new TestCaseData(1, "LowStock").SetName("qty_1");
            yield return new TestCaseData(4, "LowStock").SetName("qty_4");
            yield return new TestCaseData(5, "Available").SetName("qty_5");
            yield return new TestCaseData(15, "Available").SetName("qty_15");
        }

        [TestCaseSource(nameof(Cases))]
        public void Evaluate_Should_ReturnExpected(int qty, string expected)
        {
            var status = StockRuleEngine.Evaluate(qty);
            ClassicAssert.AreEqual(expected, status);
        }
    }
}