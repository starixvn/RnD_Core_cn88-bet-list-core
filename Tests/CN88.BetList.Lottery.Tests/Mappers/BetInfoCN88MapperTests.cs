namespace CN88.BetList.Lottery.Tests.Mappers
{
    using CN88.BetList.Core.Constants;
    using CN88.BetList.Core.Mappers;
    using NUnit.Framework;

    public class BetInfoCN88MapperTests
    {
        [TestCase(LotteryBetTypeIdConstant.MaxDice_90, LotteryBetTypeIdConstant.Max5D_60)]
        public void Init_Always_MapCorrectIdToId(int sourceId, int expectedTargetId)
        {
            // Act.
            var mapper = new BetInfoCN88Mapper();

            // Assert.
            Assert.AreEqual(mapper.MapperData[sourceId], expectedTargetId);
        }
    }
}
