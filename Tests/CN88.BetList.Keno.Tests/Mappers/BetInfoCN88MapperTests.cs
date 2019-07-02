namespace CN88.BetList.Keno.Tests.Mappers
{
    using CN88.BetList.Core.Mappers;
    using NUnit.Framework;

    public class BetInfoCN88MapperTests
    {
        [TestCase(1502, 1501)]
        [TestCase(1508, 1501)]
        [TestCase(1599, 1501)]
        public void Init_Always_MapCorrectIdToId(int sourceId, int expectedTargetId)
        {
            // Act.
            var mapper = new BetInfoCN88Mapper();

            // Assert.
            Assert.AreEqual(mapper.MapperData[sourceId], expectedTargetId);
        }
    }
}
