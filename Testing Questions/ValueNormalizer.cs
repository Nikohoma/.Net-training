using System; // ArgumentException
using NUnit.Framework.Legacy; // NUnit
using System.Text.RegularExpressions;

namespace ItTechGenie.M1.NUnit.Q1
{
    // Production code (student implements TODO)
    public static class ValueNormalizer
    {
        // ✅ TODO: Student must implement only this method
        public static int NormalizeToInt(string raw)
        {
            // TODO:
            // - handle spaces: "  10,500  "
            // - handle currency: "₹ 1,999.25" (ignore decimals => 1999)
            // - reject negatives: "-42"
            // - reject null/empty/invalid text
            if (string.IsNullOrWhiteSpace(raw)) { throw new Exception("Input is Empty."); }
            raw = raw.Trim();
            if (raw.Contains("-")) { throw new ArgumentException("Value cannot be negative."); }
            string s = "";
            foreach(var c in raw) { if (char.IsDigit(c)) { s += c; } else if (c == '.') { break; } else { continue; } }
            var rawString = int.Parse(s);
            return rawString;            

        }
    }

    // NUnit tests (do NOT change)
    [TestFixture]
    public class ValueNormalizerTests
    {
        [Test]
        public void NormalizeToInt_Should_RemoveSpacesAndCommas()
        {
            // Arrange
            var raw = "  10,500  ";                                             // input with spaces and comma

            // Act
            var result = ValueNormalizer.NormalizeToInt(raw);                    // call method

            // Assert
            ClassicAssert.AreEqual(10500, result);                                      // expected normalized value
        }

        [Test]
        public void NormalizeToInt_Should_RemoveCurrencySymbolAndDecimals()
        {
            // Arrange
            var raw = "₹ 1,999.25";                                              // currency + decimals

            // Act
            var result = ValueNormalizer.NormalizeToInt(raw);                    // call method

            // Assert
            ClassicAssert.AreEqual(1999, result);                                       // tests expect decimals to be ignored
        }

        [Test]
        public void NormalizeToInt_Should_Throw_ForNegative()
        {
            // Arrange
            var raw = " -42 ";                                                   // negative with spaces

            // Act + Assert
            Assert.Throws<ArgumentException>(() => ValueNormalizer.NormalizeToInt(raw)); // must throw
        }
    }
}