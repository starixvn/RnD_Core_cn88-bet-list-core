namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN2807Tests
    {
        private ChoiceCN2807 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN2807();
            ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetResourceData("WMBasketball", "1").Returns("Option: {0}");
        }

        [Test]
        public void ChoiceCN2807_Always_InheritChoiceCN2801()
        {
            // Assert
            Assert.AreEqual("ChoiceCN2801", typeof(ChoiceCN2807).BaseType.Name);
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

        [Test]
        public void BuildBetChoice_Always_HideKickOffTime()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.False(choice.Template.KickOffTime.Visible);
        }

        [TestCase("h", "")]
        [TestCase("h1", "Option: Home")]
        [TestCase("H1", "Option: Home")]
        [TestCase("a1", "Option: Away")]
        [TestCase("A1", "Option: Away")]
        [TestCase("o2", "")]
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
            Assert.AreEqual("\n v.  \n @ -", actualResult);
        }
    }
}
