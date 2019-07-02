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
            const int baseBetTypeId = VirtualSportsBetTypeIdConstant.Handicap;
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.OverUnder2_5Goals, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.CorrectScore, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant._1X2, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.TotalGoal, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.Moneyline, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.DoubleChance, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.Win, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.Place, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.WinPlace, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.CorrectScore_VirtualTennis, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.TotalPoints, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.Forecast, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.Tricast, baseBetTypeId);

            MapIdToBaseId(VirtualSportsBetTypeIdConstant.FT_1X2, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant._1H_1X2, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.OverUnder_VirtualSoccerNation2, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant._1HOverUnder_VirtualSoccerNation2, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.Handicap_VirtualSoccerWorldCup2, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant._1HHandicap_VirtualSoccerWorldCup2, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.CorrectScore_VirtualSoccerWorldCup2, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.MixParlay, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.MatchWinner, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant._1HWinner, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.OverUnder_VirtualBasketball2, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant._1HOverUnder_VirtualBasketball2, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.Handicap_VirtualBasketball2, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant._1HHandicap_VirtualBasketball2, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.WinningMargin6Way, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant._1HWinningMargin7Way, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.FTRaceToXPoints, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.HomeTeamOverUnder, baseBetTypeId);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.AwayTeamOverUnder, baseBetTypeId);
        }
    }
}
