namespace CN88.BetList.ESports.Tests.Mappers
{
    using CN88.BetList.Core.Constants;
    using CN88.BetList.Core.Mappers;
    using NUnit.Framework;

    public class BetInfoCN88MapperTests
    {
        [TestCase(9004, ESportsBetTypeIdConstant.MapXMoneyline)]
        [TestCase(9002, ESportsBetTypeIdConstant.MapXMoneyline)]
        [TestCase(9003, ESportsBetTypeIdConstant.MapXMoneyline)]
        [TestCase(ESportsBetTypeIdConstant.MapXFinalRoundBombPlant, ESportsBetTypeIdConstant.MapXMoneyline)]
        public void Init_Always_MapCorrectIdToId(int sourceId, int expectedTargetId)
        {
            // Act.
            var mapper = new BetInfoCN88Mapper();

            // Assert.
            Assert.AreEqual(mapper.MapperData[sourceId], expectedTargetId);
        }
    }
}
