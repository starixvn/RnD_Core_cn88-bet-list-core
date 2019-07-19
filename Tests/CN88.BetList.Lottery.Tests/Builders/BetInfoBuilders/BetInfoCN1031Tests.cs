namespace CN88.BetList.Lottery.Tests.Builders.BetInfoBuilders
{
    using CN88.BetList.Core.Builders.BetInfoBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class BetInfoCN1031Tests
    {
        private BetInfoCN1031 betInfo;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            betInfo = new BetInfoCN1031();
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void BetInfoCN1031_Always_InheritBaseBetInfoCN88()
        {
            // Assert
            Assert.AreEqual("BaseBetInfoCN88", typeof(BetInfoCN1031).BaseType.Name);
        }

        [Test]
        public void BuildBetId_Always_ReturnRefno()
        {
            // Arrange
            ticket.RefNo = "RefNo";

            // Act
            betInfo.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("RefNo", betInfo.Template.OddsTypeAndBetId.BetId.betId);
        }

        [Test]
        public void BuildOdds_Always_RenderEmpty()
        {
            // Act
            betInfo.Render(ticket, ticketHelper, null);

            // Assert
            Assert.IsEmpty(betInfo.Template.OddsTypeAndBetId.OddsType.oddsType);
        }

        [Test]
        public void BuildBetTypeName_Always_RenderCorrectText()
        {
            // Arrange
            ticketHelper.GetLotteryBetTypeName(Arg.Any<string>()).Returns("LotteryBetTypeName");

            // Act
            betInfo.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("LotteryBetTypeName", betInfo.Template.BetType.BetTypeName.betTypeName);
        }
    }
}
