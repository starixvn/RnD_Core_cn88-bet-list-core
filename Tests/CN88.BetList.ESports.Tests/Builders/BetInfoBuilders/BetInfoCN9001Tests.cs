namespace CN88.BetList.ESports.Tests.Builders.BetInfoBuilders
{
    using CN88.BetList.Core.Builders.BetInfoBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class BetInfoCN9001Tests
    {
        private BetInfoCN9001 betInfo;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            betInfo = new BetInfoCN9001();
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void BetInfoCN9001_Always_InheritBaseBetInfoCN88()
        {
            // Assert
            Assert.AreEqual("BaseBetInfoCN88", typeof(BetInfoCN9001).BaseType.Name);
        }

        [Test]
        public void BuildBetTypeName_Always_RenderCorrectText()
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
