namespace CN88.BetList.VirtualSports.Tests.Builders.BetInfoBuilders
{
    using CN88.BetList.Core.Builders.BetInfoBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class BetInfoCN2799Tests
    {
        private BetInfoCN2799 betInfo;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            betInfo = new BetInfoCN2799();
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void BetInfoCN2799_Always_InheritBaseVirtualSportsBetInfoCN88()
        {
            // Assert
            Assert.AreEqual("BaseVirtualSportsBetInfoCN88", typeof(BetInfoCN2799).BaseType.Name);
        }

        [Test]
        public void BuildOdds_Always_RenderEmpty()
        {
            // Act
            betInfo.Render(ticket, ticketHelper, null);

            // Assert
            Assert.IsEmpty(betInfo.Template.OddsTypeAndBetId.OddsType.oddsType);
        }
    }
}
