namespace CN88.BetList.Core.Mappers
{
    using Fanex.BetList.Core.Mapper;

    public class ChoiceCN88Mapper : BaseMapper
    {
        public ChoiceCN88Mapper()
        {
            Initialize();
        }

        private void Initialize()
        {
            const int BaseBetTypeId = 1501;
            const int MaxBetTypeIdRange = 1599;

            for (int betTypeId = BaseBetTypeId + 1; betTypeId <= MaxBetTypeIdRange; betTypeId++)
            {
                MapIdToBaseId(betTypeId, BaseBetTypeId);
            }
        }
    }
}
