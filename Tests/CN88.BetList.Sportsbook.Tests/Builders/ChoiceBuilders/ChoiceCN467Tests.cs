namespace CN88.BetList.Sportsbook.Tests.Builders.ChoiceBuilders
{
    using System.Collections.Generic;
    using CN88.BetList.Core.Builders.ChoiceBuilders;
    using CN88.BetList.Sportsbook.Tests.Common;
    using Fanex.BetList.Core.App_GlobalResources;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class ChoiceCN467Tests
    {
        private ChoiceCN467 _choice;
        private ITicket _ticket;
        private ITicketHelper _ticketHelper;
        private List<ITicketData> _ticketData;

        [SetUp]
        public void Setup()
        {
            _choice = new ChoiceCN467();
            _ticket = TestData.CreateTicket(BetTypes.HalfTimeFullTimeExactTotalGoals);
            _ticketHelper = Substitute.For<ITicketHelper>();
            _ticketData = Substitute.For<List<ITicketData>>();
        }

        [TestCase("G1/G2", "1", "2")]
        [TestCase(" G2 / G3 ", "2", "3")]
        [TestCase("g2/G7+", "2", "7+")]
        [TestCase("G6/g10+", "6", "10+")]
        [TestCase("g7+/g7+", "7+", "7+")]
        public void BuildChoiceName_BetTeamIsOneOfCorrectValues_SplitTotalGoalsValuesInBetTeamAndCombineWithHalfTimeFullTimeTexts(
            string betTeam,
            string expectedHalfTimeTotalGoals,
            string expectedFullTimeTotalGoals)
        {
            // Arrange.
            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, _ticketData);

            // Assert.
            var expectedDisplayedBetTeam = $"{CoreBetList.HalfTime} {expectedHalfTimeTotalGoals} / {CoreBetList.FullTime} {expectedFullTimeTotalGoals}";

            Assert.AreEqual(expectedDisplayedBetTeam, template.BetChoice.ChoiceName.choiceName);
        }

        [TestCase("G1/G2/G3")]
        [TestCase("G/G2")]
        [TestCase("g2/G")]
        [TestCase("ABCD")]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        public void BuildBetTeam_BetTeamIsIncorrect_DisplayEmptyAsBetOption(string betTeam)
        {
            // Arrange.
            _ticket.BetTeam = betTeam;

            // Act.
            var template = _choice.Render(_ticket, _ticketHelper, _ticketData);

            // Assert.
            Assert.IsEmpty(template.BetChoice.ChoiceName.choiceName);
        }
    }
}
