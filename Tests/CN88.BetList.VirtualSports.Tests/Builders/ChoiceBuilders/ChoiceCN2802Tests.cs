namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN2802Tests
    {
        private ChoiceCN2802 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            const int homeId = 1;
            const int awayId = 2;

            ticket = Substitute.For<ITicket>();
            ticket.HomeId = homeId;
            ticket.AwayId = awayId;

            choice = new ChoiceCN2802();
            ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetTeamNameById(Arg.Is<long>(i => i == homeId)).Returns("Home Name");
            ticketHelper.GetTeamNameById(Arg.Is<long>(i => i == awayId)).Returns("Away Name");
        }

        [Test]
        public void ChoiceCN2802_Always_InheritChoiceCN2801()
        {
            // Assert
            Assert.AreEqual("ChoiceCN2801", typeof(ChoiceCN2802).BaseType.Name);
        }

        [Test]
        public void BuildBetChoice_Always_HideLiveScore()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.False(choice.Template.Match.LiveScore.Visible);
        }

        [Test]
        public void BuildBetChoice_Always_HideMoreInfoAndChoiceValue()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.BetChoiceMoreInfo.Visible && !choice.Template.BetChoice.ChoiceValue.Visible);
        }

        [TestCase("h", "")]
        [TestCase("1", "Home Name")]
        [TestCase("2", "Away Name")]
        [TestCase("x", "Draw")]
        public void BuildBetChoice_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            ticket.BetTeam = betTeam;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
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
            Assert.AreEqual("\nHome Name v. Away Name \n\n @ -", actualResult);
        }
    }
}
