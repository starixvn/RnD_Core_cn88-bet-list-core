namespace CN88.BetList.VirtualSports.Tests.Mappers
{
    using CN88.BetList.Core.Constants;
    using CN88.BetList.Core.Mappers;
    using NUnit.Framework;

    public class BetInfoCN88MapperTests
    {
        [TestCase(VirtualSportsBetTypeIdConstant.OverUnder2_5Goals, VirtualSportsBetTypeIdConstant.Handicap)]
        [TestCase(VirtualSportsBetTypeIdConstant.CorrectScore, VirtualSportsBetTypeIdConstant.Handicap)]
        public void Init_Always_MapCorrectIdToId(int sourceId, int expectedTargetId)
        {
            // Act.
            var mapper = new BetInfoCN88Mapper();

            // Assert.
            Assert.AreEqual(mapper.MapperData[sourceId], expectedTargetId);
        }
    }
}
