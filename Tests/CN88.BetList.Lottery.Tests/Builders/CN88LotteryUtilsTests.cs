namespace CN88.BetList.Lottery.Tests.Builders
{
    using CN88.BetList.Core.Builders;
    using NUnit.Framework;

    public class CN88LotteryUtilsTests
    {
        [Test]
        public void ParseTransDesc_TransDescNotHaveComma_ReturnNullGameIdAndChoiceId()
        {
            // Act
            var actualValue = CN88LotteryUtils.ParseTransDesc("transDesc");

            // Assert
            Assert.True(actualValue["gameId"] == null && actualValue["choiceId"] == null);
        }

        [Test]
        public void ParseTransDesc_TransDescNotHaveBetChoice_ReturnNullGameIdAndCorrectChoiceId()
        {
            // Act
            var actualValue = CN88LotteryUtils.ParseTransDesc("transDesc=1,3;");

            // Assert
            Assert.True(actualValue["gameId"] == null && actualValue["choiceId"] == "3");
        }

        [Test]
        public void ParseTransDesc_TransDescHaveBetChoice_ReturnCorrectGameIdAndChoiceId()
        {
            // Act
            var actualValue = CN88LotteryUtils.ParseTransDesc("betChoice=1,3;");

            // Assert
            Assert.True(actualValue["gameId"] == "1" && actualValue["choiceId"] == "3");
        }
    }
}
