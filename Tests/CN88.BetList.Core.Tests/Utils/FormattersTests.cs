namespace CN88.BetList.Core.Tests.Utils
{
    using CN88.BetList.Core.Utils;
    using NUnit.Framework;

    public class FormattersTests
    {
        [TestCase(1, "1")]
        [TestCase(1.2, "1.2")]
        [TestCase(1.23, "1.2")]
        [TestCase(0, "0")]
        [TestCase(0.2, "0.2")]
        [TestCase(0.23, "0.2")]
        public void ToHandicap_Always_ReturnCorrectValue(decimal value, string expectedValue)
        {
            // Act
            var actualValue = value.ToHandicap();

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
