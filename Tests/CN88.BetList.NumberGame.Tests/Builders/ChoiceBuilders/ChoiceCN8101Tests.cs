namespace CN88.BetList.NumberGame.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN8101Tests
    {
        private ChoiceCN8101 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            choice = new ChoiceCN8101();
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            ticketHelper.GetResourceData("H5_BetChoice", Arg.Any<string>()).Returns("Happy 5");
        }

        [Test]
        public void ChoiceCN8101_Always_InheritBaseNumberGameChoiceCN88()
        {
            // Assert
            Assert.AreEqual("BaseNumberGameChoiceCN88", typeof(ChoiceCN8101).BaseType.Name);
        }

        [TestCase(null)]
        [TestCase("")]
        public void BuildChoiceValue_NullOrEmptyBetTeam_RenderCorrectText(string betTeam)
        {
            // Arrange
            ticket.BetTeam = betTeam;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.IsEmpty(choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [Test]
        public void BuildChoiceValue_NotNullOrEmptyBetTeam_RenderCorrectText()
        {
            // Arrange
            ticket.BetTeam = "BetTeam";

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("Happy 5", choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [Test]
        public void BuildMatch_Always_RenderCorrectHomeTeam()
        {
            // Arrange
            ticket.MatchCode = "MatchCode";

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual("No.&nbsp;MatchCode", choice.Template.Match.homeTeam);
        }

        [Test]
        public void BuildMatch_Always_RenderCorrectAwayTeam()
        {
            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.IsEmpty(choice.Template.Match.awayTeam);
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
            Assert.AreEqual("\nNo. MatchCode\n @ -", actualResult);
        }
    }
}
