namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN1231Tests
    {
        private ChoiceCN1231 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN1231();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void ChoiceCN1231_Always_InheritBaseVirtualSportsChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseVirtualSportsChoiceCN88", typeof(ChoiceCN1231).BaseType.Name);
        }

        [Test]
        public void BuildMatch_Always_HideCorrectElements()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.MatchByTeamId.Visible
                && !choice.Template.Match.Visible);
        }

        [Test]
        public void BuildKickOffTime_Always_ShowKickOffTime()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(choice.Template.KickOffTime.Visible);
        }

        [Test]
        public void BuildKickOffTime_Always_RenderCorrectKickOffTime()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("", choice.Template.KickOffTime.kickOffTime);
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
            Assert.AreEqual("\n\n -  @ 0", actualResult);
        }

        [TestCase(null, "0")]
        [TestCase("", "0")]
        [TestCase("1", "1")]
        public void BuildOdds_NullTicketData_RenderCorrectOdds(string oddsType, string expectedText)
        {
            // Arrange
            ticket.BetTypeId = 1;
            ticket.OddsType = oddsType;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.Odds.odds);
        }

        [Test]
        public void BuildChoiceName_Always_RenderCorrectText()
        {
            // Arrange
            ticket.MatchCode = "MatchCode";
            ticketHelper.GetHorseTeamNameById(Arg.Any<object>()).Returns("HomeTeam");

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("MatchCode - HomeTeam", choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [Test]
        public void BuildChoiceName_Always_HideCorrectElements()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.BetChoiceMoreInfo.Visible
                && !choice.Template.BetChoice.ChoiceValue.Visible);
        }
    }
}
