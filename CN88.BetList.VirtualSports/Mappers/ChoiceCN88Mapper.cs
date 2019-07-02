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
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.Place, VirtualSportsBetTypeIdConstant.Win);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.Forecast, VirtualSportsBetTypeIdConstant.Handicap);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.Tricast, VirtualSportsBetTypeIdConstant.Handicap);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant._1HOverUnder_VirtualSoccerNation2, VirtualSportsBetTypeIdConstant.OverUnder_VirtualSoccerNation2);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant._1HHandicap_VirtualSoccerWorldCup2, VirtualSportsBetTypeIdConstant.Handicap_VirtualSoccerWorldCup2);

            MapIdToBaseId(VirtualSportsBetTypeIdConstant._1HOverUnder_VirtualBasketball2, VirtualSportsBetTypeIdConstant.OverUnder_VirtualBasketball2);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant._1HHandicap_VirtualBasketball2, VirtualSportsBetTypeIdConstant.Handicap_VirtualBasketball2);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.HomeTeamOverUnder, VirtualSportsBetTypeIdConstant.OverUnder_VirtualBasketball2);
            MapIdToBaseId(VirtualSportsBetTypeIdConstant.AwayTeamOverUnder, VirtualSportsBetTypeIdConstant.OverUnder_VirtualBasketball2);
        }
    }
}
