namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN416Tests
    {
        private ChoiceCN416 choice;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();
            choice = new ChoiceCN416();
        }

        [Test]
        public void ChoiceCN416_Always_InheritChoiceCN4()
        {
            // Assert
            Assert.AreEqual("ChoiceCN4", typeof(ChoiceCN416).BaseType.Name);
        }

        [TestCase("", "")]
        [TestCase("1/2", "Half Time 1 / Full Time 2")]
        public void BuildBetChoice_Always_RenderCorrectChoiceName(string betTeam, string expectedText)
        {
            // Arrange
            ticket.BetTeam = betTeam;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoice.ChoiceName.choiceName);
        }

        [TestCase(null)]
        [TestCase("")]
        public void BuildBetChoice_TransDescEmpty_NotShowBetChoiceMoreInfo(string transDesc)
        {
            // Arrange
            ticket.TransDesc = transDesc;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.False(choice.Template.BetChoiceMoreInfo.Visible);
        }

        [Test]
        public void BuildBetChoice_BetTeamNotStartOrEndWithAOS_NotShowBetChoiceMoreInfo()
        {
            // Arrange
            ticket.BetTeam = "1/2";
            ticket.TransDesc = "1/2";

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.False(choice.Template.BetChoiceMoreInfo.Visible);
        }

        [TestCase("AOS:1/2AOS", "1/2", "AOS HT Excluding: 1<br/>AOS FT Excluding: 2")]
        [TestCase("AOS:1/2", "1/2", "AOS HT Excluding: 1")]
        [TestCase("1/2AOS", "1/2", "AOS FT Excluding: 2")]
        public void BuildBetChoice_ShowCorrectBetChoiceMoreInfo(string betTeam, string transDesc, string expectedText)
        {
            // Arrange
            ticket.TransDesc = transDesc;
            ticket.BetTeam = betTeam;

            // Act
            choice.Render(ticket, ticketHelper, null);

            // Assert
            Assert.AreEqual(expectedText, choice.Template.BetChoiceMoreInfo.betChoiceMoreInfo);
        }
    }
}
