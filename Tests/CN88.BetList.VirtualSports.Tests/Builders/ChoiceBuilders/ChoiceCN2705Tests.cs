namespace CN88.BetList.VirtualSports.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN2705Tests
    {
        private ChoiceCN2705 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            choice = new ChoiceCN2705();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void ChoiceCN2705_Always_InheritChoiceCN1201()
        {
            // Assert
            Assert.AreEqual("ChoiceCN1201", typeof(ChoiceCN2705).BaseType.Name);
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
            Assert.AreEqual("\n 0  \n\n @ -", actualResult);
        }
    }
}
