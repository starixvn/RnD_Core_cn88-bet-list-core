namespace CN88.BetList.NumberGame.Tests.Mappers
{
    using CN88.BetList.Core.Constants;
    using CN88.BetList.Core.Mappers;
    using NUnit.Framework;

    public class ChoiceCN88MapperTests
    {
        [TestCase(NumberGameBetTypeIdConstant.LastBallOU, NumberGameBetTypeIdConstant._1stBallOU)]
        [TestCase(NumberGameBetTypeIdConstant.EndRange_Happy5, NumberGameBetTypeIdConstant.BigSmall_Happy5)]
        public void Init_Always_MapCorrectIdToId(int sourceId, int expectedTargetId)
        {
            // Act.
            var mapper = new ChoiceCN88Mapper();

            // Assert.
            Assert.AreEqual(mapper.MapperData[sourceId], expectedTargetId);
        }
    }
}
