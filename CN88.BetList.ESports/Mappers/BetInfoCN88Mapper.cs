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
            MapForESports2Moneyline();
            MapForESports2Handicap();
            MapForESports2OverUnder();
            MapForESports2OddEven();
            MapForESports2CorrectScore();
        }

        private void MapForESports2Moneyline()
        {
            var moneylineBasedBetTypes = new[]
            {
                ESportsBetTypeIdConstant.MapXTotalKillsMoneyline,
                ESportsBetTypeIdConstant.MapXFirstBlood,
                ESportsBetTypeIdConstant.MapXFirsttoYKills,
                ESportsBetTypeIdConstant.MapXTotalTowersMoneyline,
                ESportsBetTypeIdConstant.MapXFirstTierYTower,
                ESportsBetTypeIdConstant.MapXTotalRoshansMoneyline,
                ESportsBetTypeIdConstant.MapX1stRoshan,
                ESportsBetTypeIdConstant.MapX2ndRoshan,
                ESportsBetTypeIdConstant.MapX3rdRoshan,
                ESportsBetTypeIdConstant.MapXTotalBarracksMoneyline,
                ESportsBetTypeIdConstant.MapXBarracks1stLane,
                ESportsBetTypeIdConstant.MapXBarracks2ndLane,
                ESportsBetTypeIdConstant.MapXBarracks3rdLane,
                ESportsBetTypeIdConstant.MapXTotalTurretsMoneyline,
                ESportsBetTypeIdConstant.MapXFirstTierYTurret,
                ESportsBetTypeIdConstant.MapXTotalDragonsMoneyline,
                ESportsBetTypeIdConstant.MapX1stDragon,
                ESportsBetTypeIdConstant.MapX2ndDragon,
                ESportsBetTypeIdConstant.MapX3rdDragon,
                ESportsBetTypeIdConstant.MapXTotalBaronsMoneyline,
                ESportsBetTypeIdConstant.MapX1stBaron,
                ESportsBetTypeIdConstant.MapX2ndBaron,
                ESportsBetTypeIdConstant.MapX3rdBaron,
                ESportsBetTypeIdConstant.MapXTotalInhibitorsMoneyline,
                ESportsBetTypeIdConstant.MapX1stInhibitor,
                ESportsBetTypeIdConstant.MapX2ndInhibitor,
                ESportsBetTypeIdConstant.MapX3rdInhibitor,
                ESportsBetTypeIdConstant.MapXTotalTyrantsMoneyline,
                ESportsBetTypeIdConstant.MapX1stTyrant,
                ESportsBetTypeIdConstant.MapX2ndTyrant,
                ESportsBetTypeIdConstant.MapX3rdTyrant,
                ESportsBetTypeIdConstant.MapXTotalOverlordsMoneyline,
                ESportsBetTypeIdConstant.MapX1stOverlord,
                ESportsBetTypeIdConstant.MapX2ndOverlord,
                ESportsBetTypeIdConstant.MapX3rdOverlord,
                ESportsBetTypeIdConstant.MapXFirsttoYRounds,
                ESportsBetTypeIdConstant.MapXFirstHalf,
                ESportsBetTypeIdConstant.MapXSecondHalf,
                ESportsBetTypeIdConstant.MapXMostFirstKill,
                ESportsBetTypeIdConstant.MapXClutches,
                ESportsBetTypeIdConstant.MapX16thRound,
                ESportsBetTypeIdConstant.MapXRoundYMoneyline,
                ESportsBetTypeIdConstant.MapXRoundYTotalKillsMoneyline,
                ESportsBetTypeIdConstant.MapXRoundYFirstKill
            };

            foreach (var betTypeId in moneylineBasedBetTypes)
            {
                MapIdToBaseId(betTypeId, ESportsBetTypeIdConstant.MapXMoneyline);
            }
        }

        private void MapForESports2Handicap()
        {
            var handicapBasedBetTypes = new[]
            {
                ESportsBetTypeIdConstant.MapXTotalKillsHandicap,
                ESportsBetTypeIdConstant.MapXTotalTowersHandicap,
                ESportsBetTypeIdConstant.MapXTotalRoshansHandicap,
                ESportsBetTypeIdConstant.MapXTotalBarracksHandicap,
                ESportsBetTypeIdConstant.MapXTotalTurretsHandicap,
                ESportsBetTypeIdConstant.MapXTotalDragonsHandicap,
                ESportsBetTypeIdConstant.MapXTotalBaronsHandicap,
                ESportsBetTypeIdConstant.MapXTotalInhibitorsHandicap,
                ESportsBetTypeIdConstant.MapXTotalTyrantsHandicap,
                ESportsBetTypeIdConstant.MapXTotalOverlordsHandicap,
                ESportsBetTypeIdConstant.MapXRoundsHandicap,
                ESportsBetTypeIdConstant.MapXClutchesHandicap,
                ESportsBetTypeIdConstant.MapXRoundYTotalKillsHandicap,
                ESportsBetTypeIdConstant.MapXRoundYBombPlant
            };

            foreach (var betTypeId in handicapBasedBetTypes)
            {
                MapIdToBaseId(betTypeId, ESportsBetTypeIdConstant.MapXMoneyline);
            }
        }

        private void MapForESports2OverUnder()
        {
            var overUnderBasedBetTypes = new[]
            {
                9003,
                9009,
                9013,
                9019,
                9025,
                9029,
                9035,
                9041,
                9047,
                9053,
                9058,
                9060,
                9070,
                9074
            };

            foreach (var betTypeId in overUnderBasedBetTypes)
            {
                MapIdToBaseId(betTypeId, ESportsBetTypeIdConstant.MapXMoneyline);
            }
        }

        private void MapForESports2OddEven()
        {
            var oddEvenBasedBetTypes = new[]
            {
                9005,
                9061,
                9071,
                9078,
                9079,
                9080,
                9081,
                9082,
                9083,
                9084,
                9085,
                9086
            };

            foreach (var betTypeId in oddEvenBasedBetTypes)
            {
                MapIdToBaseId(betTypeId, ESportsBetTypeIdConstant.MapXMoneyline);
            }
        }

        private void MapForESports2CorrectScore()
        {
            // Map 'Map X Final Round Bomb Plant' to 'Map X Round Y Bomb Plant'
            MapIdToBaseId(ESportsBetTypeIdConstant.MapXFinalRoundBombPlant, ESportsBetTypeIdConstant.MapXMoneyline);
        }
    }
}
