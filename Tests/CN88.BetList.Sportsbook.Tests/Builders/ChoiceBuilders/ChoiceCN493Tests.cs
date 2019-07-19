namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN493Tests
    {
        private ChoiceCN493 _choice;
        private ITicket _ticket;
        private ITicketHelper _ticketHelper;

        [SetUp]
        public void Setup()
        {
            _choice = new ChoiceCN493();
            _ticket = Substitute.For<ITicket>();
            _ticketHelper = Substitute.For<ITicketHelper>();
        }

        [TestCase("aos")]
        [TestCase("Aos")]
        [TestCase("AOS")]
        public void BuildBetTeam_TicketBetTeamIsAOS_DisplayedBetTeamIsAOS(string betTeam)
        {
            // Arrange.
            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            Assert.AreEqual(CoreBetList.AOS, template.BetChoice.ChoiceName.choiceName);
        }

        [Test]
        public void BuildBetTeam_TicketBetTeamIsAOSAndHasTransDesc_DisplayedMoreInfo()
        {
            // Arrange.
            _ticket.BetTeam = "AOS";
            _ticket.TransDesc = "1,2";

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            Assert.AreEqual("Excluding: 1, 2", template.BetChoiceMoreInfo.betChoiceMoreInfo);
        }

        [TestCase("1/2", "1", "2")]
        [TestCase("2 /10+", "2", "10+")]
        [TestCase("3/ 6", "3", "6")]
        [TestCase(" 4 / 9 ", "4", "9")]
        public void BuildBetTeam_TicketBetTeamContainsTwoTotalConersValues_DisplayHalfTimeTotalCornersAndFullTimeTotalCornersAsBetTeam(
            string betTeam,
            string expectedHalfTimeTotalCorners,
            string expectedFullTimeTotalCorners)
        {
            // Arrange.
            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            var expectedDisplayedBetTeam = $"{CoreBetList.HalfTime} {expectedHalfTimeTotalCorners} / {CoreBetList.FullTime} {expectedFullTimeTotalCorners}";

            Assert.AreEqual(expectedDisplayedBetTeam, template.BetChoice.ChoiceName.choiceName);
        }

        [TestCase("1/2/3")]
        [TestCase("anyotherscore")]
        [TestCase("1/")]
        [TestCase("2")]
        [TestCase("/3")]
        public void BuildBetTeam_TicketBetTeamIsIncorrectFormat_DisplayedBetTeamIsEmpty(string betTeam)
        {
            // Arrange.
            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            Assert.IsEmpty(template.BetChoice.ChoiceName.choiceName);
        }
    }
}
