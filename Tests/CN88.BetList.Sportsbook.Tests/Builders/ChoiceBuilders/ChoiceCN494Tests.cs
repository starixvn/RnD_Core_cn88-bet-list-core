namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN494Tests
    {
        private ChoiceCN494 _choice;
        private ITicket _ticket;
        private ITicketHelper _ticketHelper;

        [SetUp]
        public void Setup()
        {
            _choice = new ChoiceCN494();
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

        [Test]
        public void BuildBetTeam_TicketBetTeamIsNotAOS_DisplayedBetTeamIsTicketBetTeam()
        {
            // Arrange.
            const string betTeam = "1-0";

            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, null);

            // Assert.
            Assert.AreEqual(betTeam, template.BetChoice.ChoiceName.choiceName);
        }
    }
}
