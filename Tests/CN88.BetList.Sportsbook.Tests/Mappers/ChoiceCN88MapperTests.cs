namespace CN88.BetList.Sportsbook.Tests.Mappers
{
    using CN88.BetList.Core.Constants;
    using CN88.BetList.Core.Mappers;
    using NUnit.Framework;

    public class ChoiceCN88MapperTests
    {
        [TestCase(SportsbookBetTypeIdConstant.ResultTotalGoals, SportsbookBetTypeIdConstant._1HResultTotalGoals)]
        [TestCase(SportsbookBetTypeIdConstant._1HDoubleChance, SportsbookBetTypeIdConstant.DoubleChance)]
        [TestCase(SportsbookBetTypeIdConstant._1HOverUnder, SportsbookBetTypeIdConstant.OverUnder)]
        [TestCase(SportsbookBetTypeIdConstant.AwayTeamOverUnder, SportsbookBetTypeIdConstant.HomeTeamOverUnder)]
        [TestCase(SportsbookBetTypeIdConstant.Next5Minutes, SportsbookBetTypeIdConstant.Next1Minute)]
        [TestCase(SportsbookBetTypeIdConstant._1HCorrectScore, SportsbookBetTypeIdConstant.CorrectScore)]
        [TestCase(SportsbookBetTypeIdConstant.TeamScoreFirstBasket, SportsbookBetTypeIdConstant.TeamScoreHighestQuarter)]
        [TestCase(SportsbookBetTypeIdConstant._1HOddEven, SportsbookBetTypeIdConstant.OddEven)]
        public void Init_Always_MapCorrectIdToId(int sourceId, int expectedTargetId)
        {
            // Act.
            var mapper = new ChoiceCN88Mapper();

            // Assert.
            Assert.AreEqual(mapper.MapperData[sourceId], expectedTargetId);
        }
    }
}
