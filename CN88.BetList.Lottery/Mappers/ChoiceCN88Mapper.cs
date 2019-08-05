namespace CN88.BetList.Core.Mappers
{
    using CN88.BetList.Core.Constants;
    using Fanex.BetList.Core.Mapper;

    public class ChoiceCN88Mapper : BaseMapper
    {
        public ChoiceCN88Mapper()
        {
            Initialize();
        }

        private void Initialize()
        {
            const int BaseBetTypeId = LotteryBetTypeIdConstant.Max5D_60;
            const int MaxBetTypeIdRange = 1049;

            for (int betTypeId = BaseBetTypeId + 1; betTypeId <= MaxBetTypeIdRange; betTypeId++)
            {
                if (betTypeId == LotteryBetTypeIdConstant.MaxDice_60 ||
                    betTypeId == LotteryBetTypeIdConstant.MaxDice_90)
                {
                    continue;
                }

                MapIdToBaseId(betTypeId, BaseBetTypeId);
            }

            MapIdToBaseId(LotteryBetTypeIdConstant.MaxDice_90, LotteryBetTypeIdConstant.MaxDice_60);
        }
    }
}
