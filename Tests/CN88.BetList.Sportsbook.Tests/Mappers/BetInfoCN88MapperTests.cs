namespace CN88.BetList.Sportsbook.Tests.Mappers
{
    using CN88.BetList.Core.Constants;
    using CN88.BetList.Core.Mappers;
    using NUnit.Framework;

    public class BetInfoCN88MapperTests
    {
        [TestCase(155, SportsbookBetTypeIdConstant.SetxWinner)]
        [TestCase(410, SportsbookBetTypeIdConstant.ExactHomeTeamGoals)]
        [TestCase(SportsbookBetTypeIdConstant.GameXPointHandicap, SportsbookBetTypeIdConstant.GameXWinner)]
        [TestCase(SportsbookBetTypeIdConstant.GameXPointOverUnder, SportsbookBetTypeIdConstant.GameXWinner)]
        [TestCase(SportsbookBetTypeIdConstant.GameXPointOddEven, SportsbookBetTypeIdConstant.GameXWinner)]
        [TestCase(SportsbookBetTypeIdConstant.GameXWinningMargin, SportsbookBetTypeIdConstant.GameXWinner)]
        [TestCase(SportsbookBetTypeIdConstant.GameXRaceToYPoints, SportsbookBetTypeIdConstant.GameXWinner)]
        [TestCase(SportsbookBetTypeIdConstant.GameXPointYWinner, SportsbookBetTypeIdConstant.GameXWinner)]
        [TestCase(SportsbookBetTypeIdConstant.GameXExtraPoints, SportsbookBetTypeIdConstant.GameXWinner)]
        public void Init_Always_MapCorrectIdToId(int sourceId, int expectedTargetId)
        {
            // Act.
            var mapper = new BetInfoCN88Mapper();

            // Assert.
            Assert.AreEqual(mapper.MapperData[sourceId], expectedTargetId);
        }
    }
}
