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
            MapIdToBaseId(NumberGameBetTypeIdConstant.LastBallOU, NumberGameBetTypeIdConstant._1stBallOU);
            MapIdToBaseId(NumberGameBetTypeIdConstant.LastBallOE, NumberGameBetTypeIdConstant._1stBallOE);

            MapHappy5();
        }

        private void MapHappy5()
        {
            const int baseBetTypeId = NumberGameBetTypeIdConstant.BigSmall_Happy5;
            const int endOfBetTypeRange = NumberGameBetTypeIdConstant.EndRange_Happy5;

            for (var betTypeId = baseBetTypeId + 1; betTypeId <= endOfBetTypeRange; betTypeId++)
            {
                MapIdToBaseId(betTypeId, baseBetTypeId);
            }
        }
    }
}
