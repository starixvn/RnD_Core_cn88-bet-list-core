namespace CN88.BetList.Sportsbook.Tests.Mappers
{
    using CN88.BetList.Core.Constants;
    using CN88.BetList.Core.Mappers;
    using NUnit.Framework;

    public class ParentChildCN88MapperTests
    {
        [TestCase(SportsbookBetTypeIdConstant._2HOverUnder3rd, SportsbookBetTypeIdConstant._2HOverUnder)]
        [TestCase(SportsbookBetTypeIdConstant.Exact1HGoals3rd, SportsbookBetTypeIdConstant.Exact1HGoals)]
        [TestCase(SportsbookBetTypeIdConstant._2HHandicap3rd, SportsbookBetTypeIdConstant._2HHandicap)]
        public void Init_Always_MapCorrectIdToId(int sourceId, int expectedTargetId)
        {
            // Act.
            var mapper = new ParentChildCN88Mapper();

            // Assert.
            Assert.AreEqual(mapper.MapperData[sourceId], expectedTargetId);
        }
    }
}
