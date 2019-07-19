namespace CN88.BetList.Sportsbook.Tests.Builders.BetInfoBuilders
{
    using CN88.BetList.Core.Builders.BetInfoBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class BetInfoCN29Tests
    {
        private BetInfoCN29 betInfo;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            betInfo = new BetInfoCN29();
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetBetTypeNameById(9).Returns("MixParlayBetTypeId");
            ticketHelper.GetBetTypeNameById(2).Returns("BasketBall");
            ticketHelper.GetResourceData("ComboParlay", "LuckyBet").Returns("LuckyBet");
        }

        [Test]
        public void BetInfoCN29_Always_InheritBaseBetInfoCN88()
        {
            // Assert
            Assert.AreEqual("BaseBetInfoCN88", typeof(BetInfoCN29).BaseType.Name);
        }

        [Test]
        public void GetBetTypeName_MixParlay_ReturnCorrectText()
        {
            // Arrange 
            ticket.BetTeam = "1";
            var expectedText = "MixParlayBetTypeId";

            // Act
            var actualValue = betInfo.RenderBetTypeName(ticket, ticketHelper);

            // Assert
            Assert.AreEqual(expectedText, actualValue);
        }

        [Test]
        public void GetBetTypeName_LuckyBet_ReturnCorrectText()
        {
            // Arrange 
            ticket.BetTeam = "3";
            ticket.BetCheck = "3";
            ticket.Handicap1 = 0;
            ticket.BetTypeId = 2;
            var expectedText = "BasketBall LuckyBet";

            // Act
            var actualValue = betInfo.RenderBetTypeName(ticket, ticketHelper);

            // Assert
            Assert.AreEqual(expectedText, actualValue);
        }

        [TestCase("3", 1)]
        [TestCase("4", 0)]
        [TestCase("4", 1)]
        public void GetBetTypeName_NotLuckyBet_ReturnCorrectText(string betCheck, decimal hdp1)
        {
            // Arrange 
            ticket.BetTeam = "3";
            ticket.BetCheck = betCheck;
            ticket.Handicap1 = hdp1;
            ticket.BetTypeId = 2;
            var expectedText = "BasketBall";

            // Act
            var actualValue = betInfo.RenderBetTypeName(ticket, ticketHelper);

            // Assert
            Assert.AreEqual(expectedText, actualValue);
        }
    }
}
