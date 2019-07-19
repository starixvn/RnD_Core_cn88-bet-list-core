namespace CN88.BetList.NumberGame.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN81Tests
    {
        private ChoiceCN81 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            choice = new ChoiceCN81();
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
        }

        [Test]
        public void ChoiceCN81_Always_InheritBaseNumberGameChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseNumberGameChoiceCN88", typeof(ChoiceCN81).BaseType.Name);
        }

        [TestCase("h", "Over <span style='color:#555555;font-weight: bold;'>37.5</span>")]
        [TestCase("H", "Over <span style='color:#555555;font-weight: bold;'>37.5</span>")]
        [TestCase("a", "Under <span style='color:#555555;font-weight: bold;'>37.5</span>")]
        [TestCase("A", "Under <span style='color:#555555;font-weight: bold;'>37.5</span>")]
        [TestCase("", "Under <span style='color:#555555;font-weight: bold;'>37.5</span>")]
        public void BuildChoiceName_Always_RenderCorrectText(string betTeam, string expectedText)
        {
            // Arrange
            ticket.BetTeam = betTeam;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [Test]
        public void BuildMatchRtf_Always_RenderCorrectValue()
        {
            // Arrange
            ticket.MatchCode = "MatchCode";
            var ticketData = new List<ITicketData>();
            var rtfHelper = new RTFHelper
            {
                RTFRenderer = new RtfTextRender()
            };

            // Act
            var actualResult = choice.RenderRTF(ticket, ticketHelper, ticketData, rtfHelper)[0].ToString();

            // Assert
            Assert.AreEqual("\nNumber Game No MatchCode\nUnder 37.5 @ -", actualResult);
        }
    }
}
