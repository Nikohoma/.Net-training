using System; // Exception
using NUnit.Framework.Legacy; // NUnit
using System.Text.RegularExpressions;

namespace ItTechGenie.M1.NUnit.Q2
{
    public record InventoryItem(string Sku, string Name, decimal Price, int Qty); // model

    public static class InventoryParser
    {
        // ✅ TODO: Student must implement only this method
        public static InventoryItem ParseLine(string line, char delim)
        {
            // TODO:
            // - split by delimiter
            // - validate 4 columns
            // - parse price: "₹ 7,999" => 7999
            // - parse qty int
            // - return InventoryItem
            string[] parts = line.Split(delim);
            if (parts.Length < 4 || parts.Length > 4) { throw new Exception("Invalid Size."); }
            var pr = Regex.Replace(parts[2], @"[^0-9.,]", "");
            decimal price = Decimal.Parse(pr);  int qty = int.Parse(parts[3]);
            return new InventoryItem(parts[0], parts[1], price, qty);
        }
    }

    [TestFixture]
    public class InventoryParserTests
    {
        [TestCase("SKU-α12;Laptop Stand (Aluminium);₹ 1299.50;15", ';', "SKU-α12", 1299.50, 15)]
        [TestCase("SKU-β77;Noise-Cancel Headphones;₹ 7,999;4", ';', "SKU-β77", 7999, 4)]
        [TestCase("SKU-!@#;USB-C Hub (6-in-1);₹ 2,499.99;0", ';', "SKU-!@#", 2499.99, 0)]
        public void ParseLine_Should_ParseSkuPriceQty(string line, char delim, string sku, double price, int qty)
        {
            // Arrange + Act
            var item = InventoryParser.ParseLine(line, delim);

            // Assert
            ClassicAssert.AreEqual(sku, item.Sku);
            ClassicAssert.AreEqual((decimal)price, item.Price);
            ClassicAssert.AreEqual(qty, item.Qty);
        }
    }
}