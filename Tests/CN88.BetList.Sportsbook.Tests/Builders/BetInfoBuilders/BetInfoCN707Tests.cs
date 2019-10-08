namespace CN88.BetList.Sportsbook.Tests.Builders.BetInfoBuilders
{
    using CN88.BetList.Core.Builders.BetInfoBuilders;
    using Fanex.BetList.Core.Entities;
    using NSubstitute;
    using NUnit.Framework;

    public class BetInfoCN707Tests
    {
        private BetInfoCN707 betInfo;
        private ITicket ticket;
        private ITicketHelper ticketHelper;

        [SetUp]
        public void Setup()
        {
            betInfo = new BetInfoCN707();
            ticket = Substitute.For<ITicket>();
            ticketHelper = Substitute.For<ITicketHelper>();

            ticketHelper.GetBetTypeNameById(Arg.Any<int>(), Arg.Any<string>(), Arg.Any<long?>(), Arg.Any<string>())
                .Returns(args => args[3] + " Winner");
        }

        [Test]
        public void BetInfoCN707_Always_InheritBaseBetInfoCN88()
        {
            // Assert
            Assert.AreEqual("BaseBetInfoCN88", typeof(BetInfoCN707).BaseType.Name);
        }

        [TestCase(null, " Winner")]
        [TestCase("", " Winner")]
        [TestCase(" ", "  Winner")]
        [TestCase("a", "a Winner")]
        [TestCase("801", "801 Winner")]
        [TestCase("802", "802 Winner")]
        [TestCase("803", "803 Winner")]
        [TestCase("804", "804 Winner")]
        [TestCase("805", "805 Winner")]
        public void BuildBetTypeName_Always_RenderCorrectText(string betCheck, string expectedText)
        {
            // Arrange 
            ticket.BetCheck = betCheck;
            ticketHelper.GetBetTypeNameById(Arg.Any<object>(), Arg.Any<object>()).Returns(expectedText);

            // Act
            var actualValue = betInfo.RenderBetTypeName(ticket, ticketHelper);

            // Assert
            Assert.AreEqual(expectedText, actualValue);
        }
    }
}
