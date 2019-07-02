namespace CN88.BetList.Core.Builders.ChoiceBuilders
{
    using Fanex.BetList.Core.Entities;

    public class ChoiceCN2803 : ChoiceCN2703
    {
        protected override void BuildScore(ITicket ticket)
        {
            Template.Match.LiveScore.Visible = false;
        }
    }
}
