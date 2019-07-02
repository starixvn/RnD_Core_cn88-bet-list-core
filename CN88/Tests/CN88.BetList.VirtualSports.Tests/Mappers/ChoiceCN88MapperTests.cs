namespace CN88.BetList.VirtualSports.Tests.Mappers
{
    using CN88.BetList.Core.Constants;
    using CN88.BetList.Core.Mappers;
    using NUnit.Framework;

    public class ChoiceCN88MapperTests
    {
        [TestCase(VirtualSportsBetTypeIdConstant.Place, VirtualSportsBetTypeIdConstant.Win)]
        [TestCase(VirtualSportsBetTypeIdConstant.Forecast, VirtualSportsBetTypeIdConstant.Handicap)]
        public void Init_Always_MapCorrectIdToId(int sourceId, int expectedTargetId)
        {
            // Act.
            var mapper = new ChoiceCN88Mapper();

            // Assert.
            Assert.AreEqual(mapper.MapperData[sourceId], expectedTargetId);
        }
    }
}
