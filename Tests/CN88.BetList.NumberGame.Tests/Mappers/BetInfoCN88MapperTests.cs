namespace CN88.BetList.NumberGame.Tests.Mappers
{
    using CN88.BetList.Core.Constants;
    using CN88.BetList.Core.Mappers;
    using NUnit.Framework;

    public class BetInfoCN88MapperTests
    {
        [TestCase(NumberGameBetTypeIdConstant.LastBallOU, NumberGameBetTypeIdConstant._1stBallOU)]
        [TestCase(NumberGameBetTypeIdConstant.NextRB, NumberGameBetTypeIdConstant._1stBallOU)]
        public void Init_Always_MapCorrectIdToId(int sourceId, int expectedTargetId)
        {
            // Act.
            var mapper = new BetInfoCN88Mapper();

            // Assert.
            Assert.AreEqual(mapper.MapperData[sourceId], expectedTargetId);
        }
    }
}
