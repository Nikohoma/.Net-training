using GymStream;
using NUnit.Framework.Legacy;

namespace TestProject1
{
    public class Tests
    {
        private Membership _membership;
        [SetUp]
        public void Setup()
        {
            _membership = new Membership();
        }

        [Test]
        public void ValidateEnrollment_ValidTiers_ReturnsTrue()
        {
            _membership.Tier = "Basic";
            _membership.DurationInMonths = 1;

            ClassicAssert.IsTrue(_membership.ValidateEnrollment());
        }

        [Test]        
        public void ValidateEnrollment_InvalidTier_ThrowsInvalidTierException()
        {
            _membership.Tier = "Gold"; // Invalid tier
            _membership.DurationInMonths = 12;

            // Act & Assert
            var ex = Assert.Throws<InvalidTierException>(() => _membership.ValidateEnrollment());
            ClassicAssert.AreEqual("Tier not recognized. Please choose an available membership plan.", ex.Message);
        }

        [Test]
        public void ValidateEnrollment_ValidDuration_MoreThan0()
        {
            _membership.Tier = "Basic";
            _membership.DurationInMonths = 0;

            var ex = ClassicAssert.Throws<Exception>(() => _membership.ValidateEnrollment());
            ClassicAssert.AreEqual("Duration must be at least one month.", ex.Message);
        }

        [Test]
        [TestCase("Basic", 10, 100, 980)]    // 1000 - 2% = 980
        [TestCase("Premium", 10, 100, 930)]  // 1000 - 7% = 930
        [TestCase("Elite", 10, 100, 880)]    // 1000 - 12% = 880
        public void ValidateCalculateTotalBill_ReturnsExpectedDiscount(string tier, int duration, double basePrice, double expected)
        {
            _membership.Tier = tier;
            _membership.DurationInMonths = duration;
            _membership.BasePricePerMonth = basePrice;

            double actual = _membership.CalculateTotalBill();

            ClassicAssert.AreEqual(expected, actual);
        }

    }
}
