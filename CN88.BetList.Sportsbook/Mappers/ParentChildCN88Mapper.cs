namespace CN88.BetList.Core.Mappers
{
    using System.Diagnostics.CodeAnalysis;
    using CN88.BetList.Core.Constants;
    using Fanex.BetList.Core.Mapper;

    public class ParentChildCN88Mapper : BaseMapper
    {
        public ParentChildCN88Mapper()
        {
            Initialize();
        }

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules", "SP2101:MethodMustNotContainMoreLinesThan", Justification = "Reviewed. Suppression is OK here.")]
        private void Initialize()
        {
            ////2ND Over/Under (3rd) (178)
            MapIdToBaseId(SportsbookBetTypeIdConstant._2HOverUnder3rd, SportsbookBetTypeIdConstant._2HOverUnder);

            ////Exact 1H Goals (3rd) (179)
            MapIdToBaseId(SportsbookBetTypeIdConstant.Exact1HGoals3rd, SportsbookBetTypeIdConstant.Exact1HGoals);

            ////2ND Handicap (3rd) (183)
            MapIdToBaseId(SportsbookBetTypeIdConstant._2HHandicap3rd, SportsbookBetTypeIdConstant._2HHandicap);

            ////Exact 2H Goals (3rd)
            MapIdToBaseId(SportsbookBetTypeIdConstant.Exact2HGoals3rd, SportsbookBetTypeIdConstant.Exact2HGoals);

            ////Result And First Team To Score (own) (415)
            MapIdToBaseId(SportsbookBetTypeIdConstant.ResultAndFirstTeamToScoreOwn, SportsbookBetTypeIdConstant.ResultAndFirstTeamToScore);

            ////Half Time/ Full Time Correct Score(own) (416)
            MapIdToBaseId(SportsbookBetTypeIdConstant.HalfTimeFullTimeCorrectScoreAOS, SportsbookBetTypeIdConstant.HalfTimeFullTimeCorrectScore);

            ////1H Both Teams To Score (own) (427)
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HBothTeamsToScoreOwn, SportsbookBetTypeIdConstant._1HBothTeamsToScore);

            ////2H Odd/Even (own) (428)
            MapIdToBaseId(SportsbookBetTypeIdConstant._2HOddEvenOwn, SportsbookBetTypeIdConstant._2HOddEven);

            ////2H 1X2 (own) (430)
            MapIdToBaseId(SportsbookBetTypeIdConstant._2H1X2Own, SportsbookBetTypeIdConstant._2H1X2);

            ////2H Double Chance (own) (431)
            MapIdToBaseId(SportsbookBetTypeIdConstant._2HDoubleChanceOwn, SportsbookBetTypeIdConstant._2HDoubleChance);

            ////2H Draw No Bet (own) (432)
            MapIdToBaseId(SportsbookBetTypeIdConstant._2HDrawNoBetOwn, SportsbookBetTypeIdConstant._2HDrawNoBet);

            ////2H Both Teams To Score (own) (433)
            MapIdToBaseId(SportsbookBetTypeIdConstant._2HBothTeamsToScoreOwn, SportsbookBetTypeIdConstant._2HBothTeamsToScore);

            ////Both Halves Over 1.5 Yes/No (own) (434)
            MapIdToBaseId(SportsbookBetTypeIdConstant.BothHalvesOver1_5YesNoOwn, SportsbookBetTypeIdConstant.BothHalvesOver1_5YesNo);

            ////Both Halves Under 1.5 Yes/No (own) (435)
            MapIdToBaseId(SportsbookBetTypeIdConstant.BothHalvesUnder1_5Own, SportsbookBetTypeIdConstant.BothHalvesUnder1_5YesNo);

            ////Home To Score In Both Halves (own) (436)
            MapIdToBaseId(SportsbookBetTypeIdConstant.HomeToScoreInBothHalvesOwn, SportsbookBetTypeIdConstant.HomeToScoreInBothHalves);

            ////Away To Score In Both Halves (own) (437)
            MapIdToBaseId(SportsbookBetTypeIdConstant.AwayToScoreInBothHalvesOwn, SportsbookBetTypeIdConstant.AwayToScoreInBothHalves);

            ////Home To Win Both Halves (own) (438)
            MapIdToBaseId(SportsbookBetTypeIdConstant.HomeToWinBothHalvesOwn, SportsbookBetTypeIdConstant.HomeToWinBothHalves);

            ////Away To Win Both Halves (own) (439)
            MapIdToBaseId(SportsbookBetTypeIdConstant.AwayToWinBothHalvesOwn, SportsbookBetTypeIdConstant.AwayToWinBothHalves);

            ////Home To Win Either Half (own) (440)
            MapIdToBaseId(SportsbookBetTypeIdConstant.HomeToWinEitherHalfOwn, SportsbookBetTypeIdConstant.HomeToWinEitherHalf);

            ////Away To Win Either Half (own) (441)
            MapIdToBaseId(SportsbookBetTypeIdConstant.AwayToWinEitherHalfOwn, SportsbookBetTypeIdConstant.AwayToWinEitherHalf);

            ////Highest Scoring Half (own) (442)
            MapIdToBaseId(SportsbookBetTypeIdConstant.HighestScoringHalfOwn, SportsbookBetTypeIdConstant.HighestScoringHalf);

            ////Highest Scoring Half Home Team (own) (443)
            MapIdToBaseId(SportsbookBetTypeIdConstant.HighestScoringHalfHomeTeamOwn, SportsbookBetTypeIdConstant.HighestScoringHalfHomeTeam);

            ////Highest Scoring Half Away Team (own) (444)
            MapIdToBaseId(SportsbookBetTypeIdConstant.HighestScoringHalfAwayTeamOwn, SportsbookBetTypeIdConstant.HighestScoringHalfAwayTeam);
        }
    }
}
