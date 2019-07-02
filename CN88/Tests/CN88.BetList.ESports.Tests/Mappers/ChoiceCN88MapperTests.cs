namespace CN88.BetList.ESports.Tests.Mappers
{
    using CN88.BetList.Core.Constants;
    using CN88.BetList.Core.Mappers;
    using NUnit.Framework;

    public class ChoiceCN88MapperTests
    {
        [TestCase(9004, ESportsBetTypeIdConstant.MapXMoneyline)]
        [TestCase(9008, 1)]
        [TestCase(9009, ESportsBetTypeIdConstant.MapXTotalKillsOverUnder)]
        [TestCase(9061, ESportsBetTypeIdConstant.MapXTotalKillsOddEven)]
        [TestCase(ESportsBetTypeIdConstant.MapXFinalRoundBombPlant, ESportsBetTypeIdConstant.MapXRoundYBombPlant)]
        public void Init_Always_MapCorrectIdToId(int sourceId, int expectedTargetId)
        {
            // Act.
            var mapper = new ChoiceCN88Mapper();

            // Assert.
            Assert.AreEqual(mapper.MapperData[sourceId], expectedTargetId);
        }
    }
}
