namespace CN88.BetList.VirtualSports.Tests.Builders.BetInfoBuilders
{
    using CN88.BetList.Core.Builders.BetInfoBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class BetInfoCN2809Tests
    {
        private BetInfoCN2809 betInfo;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            betInfo = new BetInfoCN2809();
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void BetInfoCN2809_Always_InheritBaseBetInfoCN88()
        {
            // Assert
            Assert.AreEqual("BaseBetInfoCN88", typeof(BetInfoCN2809).BaseType.Name);
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
