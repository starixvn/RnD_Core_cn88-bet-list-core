namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN468Tests
    {
        private ChoiceCN468 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            choice = new ChoiceCN468();
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetResourceData(Arg.Any<string>(), Arg.Any<string>()).Returns("TotalGoalsOddsDescriptions");
        }

        [Test]
        public void ChoiceCN468_Always_InheritChoiceCN601()
        {
            // Assert
            Assert.AreEqual("BaseChoiceCN88", typeof(ChoiceCN468).BaseType.Name);
        }

        [TestCase(0, "0")]
        [TestCase(1, "1")]
        public void BuildOdds_Always_RenderCorrectText(decimal odds, string expectedText)
        {
            // Arrange
            ticket.Odds = odds;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.Odds.odds);
        }

        [Test]
        public void BuildBetChoice_NotSettledTicket_HideOdds()
        {
            // Arrange
            ticket.Status = "Running";

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.BetChoice.BetChoiceSplitChar.Visible && !choice.Template.BetChoice.Odds.Visible);
        }

        [Test]
        public void BuildBetChoice_SettledTicket_ShowOdds()
        {
            // Arrange
            ticket.Status = "Won";

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(choice.Template.BetChoice.BetChoiceSplitChar.Visible && choice.Template.BetChoice.Odds.Visible);
        }

        [Test]
        public void BuildBetChoice_HasBetTeamAndBetCheck_ShowBetChoiceMoreInfo()
        {
            // Arrange
            ticket.Status = "Won";
            ticket.BetTeam = "BetTeam";
            ticket.BetCheck = "BetCheck";

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(choice.Template.BetChoiceMoreInfo.Visible);
        }

        [Test]
        public void BuildBetChoice_HasBetTeamAndBetCheck_RenderScoreBox()
        {
            // Arrange
            ticket.Status = "Won";
            ticket.BetTeam = "O";
            ticket.BetCheck = "1:1";

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("<div class='bettype-description'>TotalGoalsOddsDescriptions</div>", choice.Template.BetChoiceMoreInfo.betChoiceMoreInfo);
        }

        [Test]
        public void BuildMatchRtf_Always_RenderCorrectValue()
        {
            // Arrange
            ticket.Status = "Won";
            ticket.BetTeam = "O";
            ticket.BetCheck = "1:1";
            var ticketData = new List<ITicketData>();
            var rtfHelper = new RTFHelper
            {
                RTFRenderer = new RtfTextRender()
            };

            // Act
            var actualResult = choice.RenderRTF(ticket, ticketHelper, ticketData, rtfHelper)[0].ToString();

            // Assert
            Assert.AreEqual("\n[0] vs [0]\n v.  \n @ 0\r\nTotalGoalsOddsDescriptions\r\n", actualResult);
        }
    }
}
