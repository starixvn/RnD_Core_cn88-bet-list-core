namespace CN88.BetList.Core.Mappers
{
    using CN88.BetList.Core.Constants;
    using Fanex.BetList.Core.Mapper;

    public class BetInfoCN88Mapper : BaseMapper
    {
        public BetInfoCN88Mapper()
        {
            Initialize();
        }

        private void Initialize()
        {
            MapIdToBaseId(NumberGameBetTypeIdConstant.LastBallOU, NumberGameBetTypeIdConstant._1stBallOU);
            MapIdToBaseId(NumberGameBetTypeIdConstant._1stBallOE, NumberGameBetTypeIdConstant._1stBallOU);
            MapIdToBaseId(NumberGameBetTypeIdConstant.LastBallOE, NumberGameBetTypeIdConstant._1stBallOU);
            MapIdToBaseId(NumberGameBetTypeIdConstant.NextHighLow, NumberGameBetTypeIdConstant._1stBallOU);
            MapIdToBaseId(NumberGameBetTypeIdConstant.Warrior, NumberGameBetTypeIdConstant._1stBallOU);
            MapIdToBaseId(NumberGameBetTypeIdConstant.NextCombo, NumberGameBetTypeIdConstant._1stBallOU);
            MapIdToBaseId(NumberGameBetTypeIdConstant.NumberWheel, NumberGameBetTypeIdConstant._1stBallOU);
            MapIdToBaseId(NumberGameBetTypeIdConstant.BigSmall_Happy5, NumberGameBetTypeIdConstant._1stBallOU);
            MapIdToBaseId(NumberGameBetTypeIdConstant.OddEven_Happy5, NumberGameBetTypeIdConstant._1stBallOU);
            MapIdToBaseId(NumberGameBetTypeIdConstant._4Seasons_Happy5, NumberGameBetTypeIdConstant._1stBallOU);
            MapIdToBaseId(NumberGameBetTypeIdConstant.MoreOddMoreEven_Happy5, NumberGameBetTypeIdConstant._1stBallOU);
            MapIdToBaseId(NumberGameBetTypeIdConstant.Combo_Happy5, NumberGameBetTypeIdConstant._1stBallOU);

            MapIdToBaseId(NumberGameBetTypeIdConstant.OddEven, NumberGameBetTypeIdConstant.OverUnder);
        }
    }
}
