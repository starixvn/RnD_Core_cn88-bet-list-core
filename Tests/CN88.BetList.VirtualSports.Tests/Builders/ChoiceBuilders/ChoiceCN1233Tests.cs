namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN1233Tests
    {
        private ChoiceCN1233 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN1233();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void ChoiceCN1233_Always_InheritChoiceCN1231()
        {
            // Assert
            Assert.AreEqual("ChoiceCN1231", typeof(ChoiceCN1233).BaseType.Name);
        }

        [Test]
        public void BuildOdds_NullTicketData_RenderCorrectOdds()
        {
            // Arrange
            List<ITicketData> ticketData = null;

            // Act
            choice.Render(ticket, ticketHelper, ticketData);

            // Assert
            Assert.AreEqual("-", choice.Template.BetChoice.Odds.odds);
        }

        [Test]
        public void BuildOdds_EmptyTicketData_RenderCorrectOdds()
        {
            // Arrange
            List<ITicketData> ticketData = new List<ITicketData>();

            // Act
            choice.Render(ticket, ticketHelper, ticketData);

            // Assert
            Assert.AreEqual("-", choice.Template.BetChoice.Odds.odds);
        }

        [Test]
        public void BuildOdds_NotFoundTicketData_RenderCorrectOdds()
        {
            // Arrange
            List<ITicketData> ticketData = new List<ITicketData>() {
                new TicketData { RefNo = "1" }
            };

            // Act
            choice.Render(ticket, ticketHelper, ticketData);

            // Assert
            Assert.AreEqual("-", choice.Template.BetChoice.Odds.odds);
        }

        [Test]
        public void BuildOdds_Found1TicketData_RenderCorrectOdds()
        {
            // Arrange
            ticket.RefNo = "1";
            List<ITicketData> ticketData = new List<ITicketData>() {
                new TicketData { RefNo = "1" }
            };

            // Act
            choice.Render(ticket, ticketHelper, ticketData);

            // Assert
            Assert.AreEqual("-", choice.Template.BetChoice.Odds.odds);
        }

        [Test]
        public void BuildOdds_FoundMoreThan1TicketData_RenderCorrectBetChoice()
        {
            // Arrange
            ticket.RefNo = "1";
            List<ITicketData> ticketData = new List<ITicketData>() {
                new TicketData { RefNo = "1", BetTypeId = 1231 },
                new TicketData { RefNo = "1", BetTypeId = 1232 }
            };

            // Act
            choice.Render(ticket, ticketHelper, ticketData);

            // Assert
            Assert.AreEqual("<span class=\"cn88-choice-name\"> - </span><span> @ </span><span class=\"cn88-odds\">0</span><span> (Win)</span><br /><span class=\"cn88-choice-name\"> - </span><span> @ </span><span class=\"cn88-odds\">0</span><span> (Place)</span>", choice.Template.BetChoice.ToString());
        }

        [Test]
        public void RenderRTF_Always_ReturnCorrectValue()
        {
            // Arrange
            var ticketData = new List<ITicketData>();
            var rtfHelper = new RTFHelper { RTFRenderer = new RtfTextRender() };

            // Act
            var actualResult = choice.RenderRTF(ticket, ticketHelper, ticketData, rtfHelper)[0].ToString();

            // Assert
            Assert.AreEqual("\n -  @ -", actualResult);
        }
    }
}
