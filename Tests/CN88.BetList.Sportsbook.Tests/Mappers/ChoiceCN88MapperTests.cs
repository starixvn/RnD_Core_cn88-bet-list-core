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
        [TestCase(SportsbookBetTypeIdConstant.CornersOddEvenOwn, SportsbookBetTypeIdConstant.FirstHalfHomeTeamOddEven)]
        [TestCase(SportsbookBetTypeIdConstant._1HCornersOddEvenOwn, SportsbookBetTypeIdConstant.FirstHalfHomeTeamOddEven)]
        [TestCase(SportsbookBetTypeIdConstant._2HCornersOddEven, SportsbookBetTypeIdConstant.FirstHalfHomeTeamOddEven)]
        [TestCase(SportsbookBetTypeIdConstant._1HTotalCornersOwn, SportsbookBetTypeIdConstant.TotalCorners)]
        [TestCase(SportsbookBetTypeIdConstant._1HAlternativeCorners, SportsbookBetTypeIdConstant.AlternativeCorners)]
        [TestCase(SportsbookBetTypeIdConstant.Corner3WayHandicap, SportsbookBetTypeIdConstant._3WayHandicap)]
        [TestCase(SportsbookBetTypeIdConstant._1HCorner3WayHandicap, SportsbookBetTypeIdConstant._3WayHandicap)]
        [TestCase(SportsbookBetTypeIdConstant.TimeOf2HFirstCorner, SportsbookBetTypeIdConstant.TimeOfFirstCorner)]
        [TestCase(SportsbookBetTypeIdConstant.AwayTeamCornersOverUnder, SportsbookBetTypeIdConstant.HomeTeamCornersOverUnder)]
        [TestCase(SportsbookBetTypeIdConstant._1HHomeTeamCornersOverUnder, SportsbookBetTypeIdConstant.HomeTeamCornersOverUnder)]
        [TestCase(SportsbookBetTypeIdConstant._1HAwayTeamCornersOverUnder, SportsbookBetTypeIdConstant.HomeTeamCornersOverUnder)]
        [TestCase(SportsbookBetTypeIdConstant._1HCornersRace, SportsbookBetTypeIdConstant.CornersRace)]
        [TestCase(SportsbookBetTypeIdConstant._1HFirstCorner2Way, SportsbookBetTypeIdConstant.FirstCorner2Way)]
        [TestCase(SportsbookBetTypeIdConstant._2HFirstCorner2Way, SportsbookBetTypeIdConstant.FirstCorner2Way)]
        [TestCase(SportsbookBetTypeIdConstant.LastCorner2Way, SportsbookBetTypeIdConstant.FirstCorner2Way)]
        [TestCase(SportsbookBetTypeIdConstant._1HLastCorner2Way, SportsbookBetTypeIdConstant.FirstCorner2Way)]
        [TestCase(SportsbookBetTypeIdConstant._2HCorrectCorners, SportsbookBetTypeIdConstant._1HCorrectCorners)]
        [TestCase(SportsbookBetTypeIdConstant.CornerHighestScoringHalf2Way, SportsbookBetTypeIdConstant.HighestScoringHalf2Way)]
        public void Init_Always_MapCorrectIdToId(int sourceId, int expectedTargetId)
        {
            // Act.
            var mapper = new ChoiceCN88Mapper();

            // Assert.
            Assert.AreEqual(mapper.MapperData[sourceId], expectedTargetId);
        }
    }
}
