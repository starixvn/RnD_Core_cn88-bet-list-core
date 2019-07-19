namespace CN88.BetList.VirtualSports.Tests.Constants
{
    using CN88.BetList.Core.Constants;
    using NUnit.Framework;

    public class VirtualSportsCommonConstantTests
    {
        [Test]
        public void HandicapHalf_Always_ReturnCorrectValue()
        {
            // Arrange
            var expectValue = 0.5m;

            // Act
            var actualValue = VirtualSportsCommonConstant.Handicap_Half;

            // Assert
            Assert.AreEqual(expectValue, actualValue);
        }

        [Test]
        public void HandicapQuarter_Always_ReturnCorrectValue()
        {
            // Arrange
            var expectValue = 0.25m;

            // Act
            var actualValue = VirtualSportsCommonConstant.Handicap_Quarter;

            // Assert
            Assert.AreEqual(expectValue, actualValue);
        }
    }
}
