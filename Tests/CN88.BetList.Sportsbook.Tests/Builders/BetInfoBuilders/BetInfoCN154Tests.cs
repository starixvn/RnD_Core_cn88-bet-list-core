namespace CN88.BetList.Sportsbook.Tests.Builders.BetInfoBuilders
{
    using CN88.BetList.Core.Builders.BetInfoBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class BetInfoCN154Tests
    {
        private BetInfoCN154 betInfo;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            betInfo = new BetInfoCN154();
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void BetInfoCN154_Always_InheritBaseBetInfoCN88()
        {
            // Assert
            Assert.AreEqual("BaseBetInfoCN88", typeof(BetInfoCN154).BaseType.Name);
        }

        [Test]
        public void GetBetTypeName_Always_ReturnCorrectText()
        {
            // Arrange 
            var expectedText = "BetTypeName";
            ticketHelper.GetBetTypeNameById(Arg.Any<object>(), Arg.Any<object>(), Arg.Any<object>(), Arg.Any<object>())
                .Returns(expectedText);

            // Act
            var actualValue = betInfo.RenderBetTypeName(ticket, ticketHelper);

            // Assert
            Assert.AreEqual(expectedText, actualValue);
        }
    }
}
