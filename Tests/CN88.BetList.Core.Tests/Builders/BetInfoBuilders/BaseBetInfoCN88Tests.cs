namespace CN88.BetList.Core.Tests.Builders.BetInfoBuilders
{
    using System;
    using CN88.BetList.Core.Builders.BetInfoBuilders;
    using Fanex.BetList.Core.Constants;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.Utils;
    using NSubstitute;
    using NUnit.Framework;

    public class BaseBetInfoCN88Tests
    {
        private BaseBetInfoCN88 _choice;
        private ITicket _ticket;
        private ITicketHelper _ticketHelper;

        [SetUp]
        public void Setup()
        {
            _choice = new BaseBetInfoCN88();
            _ticket = Substitute.For<ITicket>();

            _ticketHelper = Substitute.For<ITicketHelper>();
            _ticketHelper.GetBetTypeNameById(Arg.Any<object>(), CommonValue.RefNoDefault).Returns("CashOut");
            _ticketHelper.GetBetTypeNameById(Arg.Any<object>(), Arg.Is<object>(o => (string)o != CommonValue.RefNoDefault)).Returns("BetTypeName");
            _ticketHelper.GetSportNameById(Arg.Any<object>()).Returns("SportName");
        }

        [TestCase(false, "CashOut")]
        [TestCase(true, "(In-Play) CashOut")]
        public void RenderBetTypeName_CashoutTicketAndNotOuright_ReturnCorrectName(
            bool isLive, string expectedName)
        {
            // Arrange
            _ticket.BetdaqId = 1;
            _ticket.BetTypeId = 1;
            _ticket.IsLive = isLive;

            // Act
            var actualName = _choice.RenderBetTypeName(_ticket, _ticketHelper);

            // Assert
            Assert.AreEqual(actualName, expectedName);
        }

        [TestCase(false, "BetTypeName")]
        [TestCase(true, "(In-Play) BetTypeName")]
        public void RenderBetTypeName_CashoutTicketAndOuright_ReturnCorrectName(
            bool isLive, string expectedName)
        {
            // Arrange
            _ticket.BetdaqId = 1;
            _ticket.BetTypeId = 10;
            _ticket.IsLive = isLive;

            // Act
            var actualName = _choice.RenderBetTypeName(_ticket, _ticketHelper);

            // Assert
            Assert.AreEqual(actualName, expectedName);
        }

        [TestCase(false, "BetTypeName")]
        [TestCase(true, "(In-Play) BetTypeName")]
        public void RenderBetTypeName_NotCashoutTicketAndOuright_ReturnCorrectName(
            bool isLive, string expectedName)
        {
            // Arrange
            _ticket.BetdaqId = 2;
            _ticket.BetTypeId = 10;
            _ticket.IsLive = isLive;

            // Act
            var actualName = _choice.RenderBetTypeName(_ticket, _ticketHelper);

            // Assert
            Assert.AreEqual(actualName, expectedName);
        }

        [TestCase(false, "BetTypeName", 2, 1)]
        [TestCase(true, "(In-Play) BetTypeName", 2, 1)]
        [TestCase(false, "BetTypeName", 1, 901)]
        [TestCase(true, "(In-Play) BetTypeName", 1, 902)]
        public void RenderBetTypeName_NotCashOutTicket_ReturnCorrectName(
            bool isLive, string expectedName, int betdaqId, int betType)
        {
            // Arrange
            _ticket.BetdaqId = betdaqId;
            _ticket.BetTypeId = betType;
            _ticket.IsLive = isLive;

            // Act
            var actualName = _choice.RenderBetTypeName(_ticket, _ticketHelper);

            // Assert
            Assert.AreEqual(actualName, expectedName);
        }

        [TestCase(null, "", "")]
        [TestCase("", "", "")]
        [TestCase("1", "", "")]
        [TestCase(null, "OddsTypeName", "OddsTypeName ")]
        [TestCase("", "OddsTypeName", "OddsTypeName ")]
        [TestCase("1", "OddsTypeName", "OddsTypeName ")]
        public void Render_Always_RenderCorrectOddsType(
            string oddsType, string oddsTypeName, string expectedDisplayedText)
        {
            // Arrange
            _ticket.OddsType = oddsType;
            Func<object, string> getOddsTypeName = (o) => oddsTypeName;

            // Act
            _choice.Render(_ticket, _ticketHelper, getOddsTypeName);

            // Assert
            Assert.AreEqual(expectedDisplayedText, _choice.Template.OddsTypeAndBetId.OddsType.oddsType);
        }

        [Test]
        public void Render_Always_RenderCorrectBetId()
        {
            // Arrange
            _ticket.TransId = 100;
            Func<object, string> getOddsTypeName = (o) => "OddsTypeName";

            // Act
            _choice.Render(_ticket, _ticketHelper, getOddsTypeName);

            // Assert
            Assert.AreEqual("100", _choice.Template.OddsTypeAndBetId.BetId.betId);
        }

        [Test]
        public void Render_Always_RenderCorrectSportTypeName()
        {
            // Arrange
            Func<object, string> getOddsTypeName = (o) => "OddsTypeName";

            // Act
            _choice.Render(_ticket, _ticketHelper, getOddsTypeName);

            // Assert
            Assert.AreEqual("SportName", _choice.Template.SportType.SportTypeName.sportTypeName);
        }

        [Test]
        public void Render_Always_RenderCorrectBetTypeName()
        {
            // Arrange
            _ticket.BetdaqId = 1;
            _ticket.BetTypeId = 1;
            _ticket.IsLive = true;
            Func<object, string> getOddsTypeName = (o) => "OddsTypeName";

            // Act
            _choice.Render(_ticket, _ticketHelper, getOddsTypeName);

            // Assert
            Assert.AreEqual("(In-Play) CashOut", _choice.Template.BetType.BetTypeName.betTypeName);
        }

        [Test]
        public void RenderRTF_Always_ReturnCorrectValue()
        {
            // Arrange
            _ticket.BetdaqId = 1;
            _ticket.BetTypeId = 1;
            _ticket.IsLive = true;
            Func<object, string> getOddsTypeName = (o) => "OddsTypeName";
            var rtfHelper = new RTFHelper
            {
                RTFRenderer = new RtfTextRender()
            };

            // Act
            var actualResult = _choice.RenderRTF(_ticket, _ticketHelper, getOddsTypeName, rtfHelper);

            // Assert
            Assert.AreEqual("OddsTypeName 0\nSportName\n(In-Play) CashOut", actualResult.ToString());
        }
    }
}
