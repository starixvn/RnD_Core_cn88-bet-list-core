namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN2801Tests
    {
        private ChoiceCN2801 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN2801();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void ChoiceCN2801_Always_InheritBaseVirtualSportsChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseVirtualSportsChoiceCN88", typeof(ChoiceCN2801).BaseType.Name);
        }

        [Test]
        public void BuildBetChoice_Always_HideCorrectElements()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.True(!choice.Template.Match.LiveScore.Visible
                && !choice.Template.BetChoiceMoreInfo.Visible
                && !choice.Template.BetChoice.ChoiceValue.Visible);
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
            var ticketData = new List<ITicketData>();
            var rtfHelper = new RTFHelper { RTFRenderer = new RtfTextRender() };

            // Act
            var actualResult = choice.RenderRTF(ticket, ticketHelper, ticketData, rtfHelper)[0].ToString();

            // Assert
            Assert.AreEqual("\n v.  \n\n @ -", actualResult);
        }
    }
}
