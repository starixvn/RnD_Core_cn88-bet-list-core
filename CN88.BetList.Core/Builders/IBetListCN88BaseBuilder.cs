namespace CN88.BetList.Core.Builders
{
    using CN88.BetList.Core.Builders.BetInfoBuilders;
    using CN88.BetList.Core.Builders.ChoiceBuilders;

    public interface IBetListCN88BaseBuilder
    {
        IChoiceCN88 CreateChoiceBuilder(int betType);

        IBetInfoCN88 CreateBetInfoBuilder(int betType);
    }
}