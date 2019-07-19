namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN2707Tests
    {
        private ChoiceCN2707 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN2707();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void ChoiceCN2707_Always_InheritBaseVirtualSportsChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseVirtualSportsChoiceCN88", typeof(ChoiceCN2707).BaseType.Name);
        }

        [Test]
        public void BuildBetChoice_Always_HideMoreInfoAndChoiceValue()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.BetChoiceMoreInfo.Visible &&
                !choice.Template.BetChoice.ChoiceValue.Visible);
        }

        [TestCase("aos", "AOS")]
        [TestCase("AOS", "AOS")]
        [TestCase("1:2", "1-2")]
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
        public void BuildBetChoice_AOSTicket_RenderCorrectMoreInfo()
        {
            // Arrange
            ticket.BetTeam = "AOS";
            ticket.TransDesc = "s=\"1,2,3\"";

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("<div class=\"excluding-choices\">Excluding: 1, 2, 3</div>", choice.Template.MoreInfo.ToString());
        }

        [TestCase("s=\"1,2,3\"", true)]
        [TestCase("", false)]
        public void BuildBetChoice_AOSTicket_ShowMoreInfo(string transDesc, bool expectedVisible)
        {
            // Arrange
            ticket.BetTeam = "AOS";
            ticket.TransDesc = transDesc;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedVisible, choice.Template.MoreInfo.Visible);
        }

        [Test]
        public void BuildBetChoice_Always_ShowKickOffTime()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(choice.Template.KickOffTime.Visible);
        }

        [TestCase("", "")]
        [TestCase(null, "")]
        [TestCase("t='1'", "")]
        [TestCase("m=\"E0001\"", "")]
        public void BuildBetChoice_Always_RenderCorrectKickOffTime(string transDesc, string expectedText)
        {
            // Arrange
            ticket.TransDesc = transDesc;
            ticketHelper.GetBetRadarMatchCodeFormat("1").Returns("Match Code");

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.KickOffTime.kickOffTime);
        }

        [Test]
        public void RenderRTF_Always_ReturnCorrectValue()
        {
            // Arrange
            ticket.BetTeam = "";
            ticket.TransDesc = "";
            var ticketData = new List<ITicketData>();
            var rtfHelper = new RTFHelper { RTFRenderer = new RtfTextRender() };

            // Act
            var actualResult = choice.RenderRTF(ticket, ticketHelper, ticketData, rtfHelper)[0].ToString();

            // Assert
            Assert.AreEqual("\n v.  \n\n @ -\nExcluding: ", actualResult);
        }
    }
}
