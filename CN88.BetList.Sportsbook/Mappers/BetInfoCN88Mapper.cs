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
            MapForBadminton();
            MapForPH();

            var bettypesByRefNo = new[]
            {
                155,
                156,
                157,
                606,
                610,
                611,
                612,
                615,
                616,
                609,
                614,
                607,
                613,
                617
            };

            foreach (var betTypeId in bettypesByRefNo)
            {
                MapIdToBaseId(betTypeId, SportsbookBetTypeIdConstant.SetxWinner);
            }

            var bettypesByParentChild = new[]
            {
                410,
                411,
                413,
                416,
                461,
                409,
                414,
                462,
                463,
                464,
                415,
                427,
                428,
                430,
                431,
                432,
                433,
                434,
                435,
                436,
                437,
                438,
                439,
                440,
                441,
                442,
                443,
                444,
                406,
                408
            };

            foreach (var betTypeId in bettypesByParentChild)
            {
                MapIdToBaseId(betTypeId, SportsbookBetTypeIdConstant.ExactHomeTeamGoals);
            }
        }

        private void MapForBadminton()
        {
            MapIdToBaseId(SportsbookBetTypeIdConstant.GameXPointHandicap, SportsbookBetTypeIdConstant.GameXWinner);
            MapIdToBaseId(SportsbookBetTypeIdConstant.GameXPointOverUnder, SportsbookBetTypeIdConstant.GameXWinner);
            MapIdToBaseId(SportsbookBetTypeIdConstant.GameXPointOddEven, SportsbookBetTypeIdConstant.GameXWinner);
            MapIdToBaseId(SportsbookBetTypeIdConstant.GameXWinningMargin, SportsbookBetTypeIdConstant.GameXWinner);
            MapIdToBaseId(SportsbookBetTypeIdConstant.GameXRaceToYPoints, SportsbookBetTypeIdConstant.GameXWinner);
            MapIdToBaseId(SportsbookBetTypeIdConstant.GameXPointYWinner, SportsbookBetTypeIdConstant.GameXWinner);
            MapIdToBaseId(SportsbookBetTypeIdConstant.GameXExtraPoints, SportsbookBetTypeIdConstant.GameXWinner);
        }

        private void MapForPH()
        {
            MapIdToBaseId(SportsbookBetTypeIdConstant.PenaltyShootoutBothOneNeitherRoundX, SportsbookBetTypeIdConstant.PenaltyShootout1X2RoundX);
            MapIdToBaseId(SportsbookBetTypeIdConstant.PenaltyShootoutWoodworkRoundX, SportsbookBetTypeIdConstant.PenaltyShootout1X2RoundX);
            MapIdToBaseId(SportsbookBetTypeIdConstant.HomePenaltyShootoutRoundX, SportsbookBetTypeIdConstant.PenaltyShootout1X2RoundX);
            MapIdToBaseId(SportsbookBetTypeIdConstant.AwayPenaltyShootoutRoundX, SportsbookBetTypeIdConstant.PenaltyShootout1X2RoundX);
        }
    }
}
