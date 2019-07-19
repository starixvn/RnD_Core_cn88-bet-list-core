namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN4Tests
    {
        private ChoiceCN4 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN4();
        }

        [Test]
        public void ChoiceCN4_Always_InheritBaseChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN4).BaseType.Name);
        }

        [TestCase("AOS", "AOS")]
        [TestCase("1:2", "1-2")]
        [TestCase("", "")]
        public void BuildBetChoice_Always_RenderCorrectChoiceName(string betTeam, string expectedText)
        {
            // Arrange
            ticket.BetTeam = betTeam;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [Test]
        public void BuildBetChoice_NotAOSTicket_NotShowBetChoiceMoreInfo()
        {
            // Arrange
            ticket.BetTeam = "";

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.False(choice.Template.BetChoiceMoreInfo.Visible);
        }

        [TestCase(null)]
        [TestCase("")]
        public void BuildBetChoice_TransDescEmpty_NotShowBetChoiceMoreInfo(string transDesc)
        {
            // Arrange
            ticket.BetTeam = "AOS";
            ticket.TransDesc = transDesc;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.False(choice.Template.BetChoiceMoreInfo.Visible);
        }

        [Test]
        public void BuildBetChoice_AOSTicket_NotShowBetChoiceMoreInfo()
        {
            // Arrange
            ticket.BetTeam = "AOS";
            ticket.TransDesc = "AOS:1,2";

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("Excluding: AOS-1, 2", choice.Template.BetChoiceMoreInfo.betChoiceMoreInfo);
        }

        [Test]
        public void RenderRTF_AOS_ReturnCorrectValue()
        {
            // Arrange
            ticket.BetTeam = "AOS";
            ticket.TransDesc = "AOS:1,2";
            var ticketData = new List<ITicketData>();
            var rtfHelper = new RTFHelper
            {
                RTFRenderer = new RtfTextRender()
            };

            // Act
            var actualResult = choice.RenderRTF(ticket, ticketHelper, ticketData, rtfHelper)[0].ToString();

            // Assert
            Assert.AreEqual("\n[0] vs [0]\n v.  \nAOS @ -\nExcluding: AOS-1, 2", actualResult);
        }

        [Test]
        public void RenderRTF_NotAOS_ReturnCorrectValue()
        {
            // Arrange
            var ticketData = new List<ITicketData>();
            var rtfHelper = new RTFHelper
            {
                RTFRenderer = new RtfTextRender()
            };

            // Act
            var actualResult = choice.RenderRTF(ticket, ticketHelper, ticketData, rtfHelper)[0].ToString();

            // Assert
            Assert.AreEqual("\n[0] vs [0]\n v.  \n @ -", actualResult);
        }
    }
}
