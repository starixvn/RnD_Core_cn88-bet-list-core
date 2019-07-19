namespace CN88.BetList.Core.Mappers
{
    using CN88.BetList.Core.Constants;
    using Fanex.BetList.Core.Mapper;

    public class ChoiceCN88Mapper : BaseMapper
    {
        public ChoiceCN88Mapper()
        {
            Mapping();
        }

        private void Mapping()
        {
            MapForHandicap();
            MapForOverUnder();
            MapForCorrectScore();
            MapForOddEven();
            MapForFastMarkets();
            MapForPoolHouseAllInOne();
            MapForBasketBall();

            MapIdToBaseId(SportsbookBetTypeIdConstant.ResultTotalGoals, SportsbookBetTypeIdConstant._1HResultTotalGoals);

            MapIdToBaseId(SportsbookBetTypeIdConstant._1HDoubleChance, SportsbookBetTypeIdConstant.DoubleChance);

            ////Home Team Which Half First Goal (420)
            MapIdToBaseId(SportsbookBetTypeIdConstant.HomeTeamWhichHalfFirstGoal, SportsbookBetTypeIdConstant.WhichHalfFirstGoal);

            ////Away Team Which Half First Goal (421)
            MapIdToBaseId(SportsbookBetTypeIdConstant.AwayTeamWhichHalfFirstGoal, SportsbookBetTypeIdConstant.WhichHalfFirstGoal);

            ////First Team 3 Goals (423)
            MapIdToBaseId(SportsbookBetTypeIdConstant.FirstTeam3Goals, SportsbookBetTypeIdConstant.FirstTeam2Goals);

            MapIdToBaseId(SportsbookBetTypeIdConstant._2HBothTeamsToScoreOwn, SportsbookBetTypeIdConstant._1HBothTeamsToScoreOwn);

            MapIdToBaseId(SportsbookBetTypeIdConstant.BothHalvesOver1_5YesNoOwn, SportsbookBetTypeIdConstant._1HBothTeamsToScoreOwn);

            MapIdToBaseId(SportsbookBetTypeIdConstant.BothHalvesUnder1_5Own, SportsbookBetTypeIdConstant._1HBothTeamsToScoreOwn);

            MapIdToBaseId(SportsbookBetTypeIdConstant.HomeToScoreInBothHalvesOwn, SportsbookBetTypeIdConstant._1HBothTeamsToScoreOwn);

            MapIdToBaseId(SportsbookBetTypeIdConstant.AwayToScoreInBothHalvesOwn, SportsbookBetTypeIdConstant._1HBothTeamsToScoreOwn);

            MapIdToBaseId(SportsbookBetTypeIdConstant.HomeToWinBothHalvesOwn, SportsbookBetTypeIdConstant._1HBothTeamsToScoreOwn);

            MapIdToBaseId(SportsbookBetTypeIdConstant.AwayToWinBothHalvesOwn, SportsbookBetTypeIdConstant._1HBothTeamsToScoreOwn);

            MapIdToBaseId(SportsbookBetTypeIdConstant.HomeToWinEitherHalfOwn, SportsbookBetTypeIdConstant._1HBothTeamsToScoreOwn);

            MapIdToBaseId(SportsbookBetTypeIdConstant.AwayToWinEitherHalfOwn, SportsbookBetTypeIdConstant._1HBothTeamsToScoreOwn);

            MapIdToBaseId(SportsbookBetTypeIdConstant.HighestScoringHalfHomeTeamOwn, SportsbookBetTypeIdConstant.HighestScoringHalfOwn);

            MapIdToBaseId(SportsbookBetTypeIdConstant.HighestScoringHalfAwayTeamOwn, SportsbookBetTypeIdConstant.HighestScoringHalfOwn);

            MapIdToBaseId(SportsbookBetTypeIdConstant.Home1HToScore_2HToScore, SportsbookBetTypeIdConstant.BothTeamsToScoreIn1H_2H);

            MapIdToBaseId(SportsbookBetTypeIdConstant.Away1HToScore_2HToScore, SportsbookBetTypeIdConstant.BothTeamsToScoreIn1H_2H);

            MapForPH4B();
        }

        private void MapForHandicap()
        {
            // 7 1H Handicap
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HHandicap, SportsbookBetTypeIdConstant.Handicap);

            // 17 2H Handicap
            MapIdToBaseId(SportsbookBetTypeIdConstant._2HHandicap, SportsbookBetTypeIdConstant.Handicap);

            // 153 FT. Game HDP
            MapIdToBaseId(SportsbookBetTypeIdConstant.FTGameHDP, SportsbookBetTypeIdConstant.Handicap);

            //// 155 Set x Game Handicap
            MapIdToBaseId(SportsbookBetTypeIdConstant.SetxGameHandicap, SportsbookBetTypeIdConstant.Handicap);

            // 609 Quarter X Handicap
            MapIdToBaseId(SportsbookBetTypeIdConstant.QuarterXHandicap, SportsbookBetTypeIdConstant.Handicap);
        }

        private void MapForOverUnder()
        {
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HOverUnder, SportsbookBetTypeIdConstant.OverUnder);
        }

        private void MapForPoolHouseAllInOne()
        {
            // Map 'Away Team Over / Under' to 'Home Team Over / Under'.
            MapIdToBaseId(SportsbookBetTypeIdConstant.AwayTeamOverUnder, SportsbookBetTypeIdConstant.HomeTeamOverUnder);

            // Map '1H Home Team Over/Under' to 'Home Team Over / Under'.
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HHomeTeamOverUnder, SportsbookBetTypeIdConstant.HomeTeamOverUnder);

            // Map '1H Away Team Over/Under' to 'Home Team Over / Under'.
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HAwayTeamOverUnder, SportsbookBetTypeIdConstant.HomeTeamOverUnder);

            // Map 'Exact Away Team Goals' to 'Exact Home Team Goals'.
            MapIdToBaseId(SportsbookBetTypeIdConstant.ExactAwayTeamGoals, SportsbookBetTypeIdConstant.ExactHomeTeamGoals);

            //461 Home Team Over/Under (dec)
            MapIdToBaseId(SportsbookBetTypeIdConstant.HomeTeamOverUnderDec, SportsbookBetTypeIdConstant.HomeTeamOverUnder);

            // Map 'Away Team Over / Under(dec)' to 'Home Team Over / Under(dec)'.
            MapIdToBaseId(SportsbookBetTypeIdConstant.AwayTeamOverUnderDec, SportsbookBetTypeIdConstant.HomeTeamOverUnder);

            // Map '1H Home Team Over/Under (dec)' to 'Home Team Over / Under(dec)'.
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HHomeTeamOverUnderDec, SportsbookBetTypeIdConstant.HomeTeamOverUnder);

            // Map '1H Away Team Over/Under (dec)' to 'Home Team Over / Under(dec)'.
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HAwayTeamOverUnderDec, SportsbookBetTypeIdConstant.HomeTeamOverUnder);

            //// Map '1H 3-Way Handicap' to '3-Way Handicap'.
            MapIdToBaseId(SportsbookBetTypeIdConstant._1H3WayHandicap, SportsbookBetTypeIdConstant._3WayHandicap);

            //// Map '1H Both Teams To Score / Result' to 'Both Teams To Score / Result'.
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HBothTeamsToScoreResult, SportsbookBetTypeIdConstant.BothTeamsToScoreResult);

            //// Map '1H Both Teams To Score / Total Goals' to 'Both Teams To Score / Total Goals'.
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HBothTeamsToScore_TotalGoals, SportsbookBetTypeIdConstant.BothTeamsToScore_TotalGoals);

            //// Map 'Asian 1X2 HDP' to 'Handicap'.
            MapIdToBaseId(SportsbookBetTypeIdConstant.Asian1X2HDP, SportsbookBetTypeIdConstant.Handicap);

            //// Map '1H Asian 1X2 HDP' to 'Handicap'.
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HAsian1X2HDP, SportsbookBetTypeIdConstant.Handicap);
        }

        private void MapForFastMarkets()
        {
            // Map 'Next 5 Munites' to 'Next 1 Minute'
            MapIdToBaseId(SportsbookBetTypeIdConstant.Next5Minutes, SportsbookBetTypeIdConstant.Next1Minute);

            // Map 'What will happen first in next 5 minutes' to 'What will happen first in next 1 minute'
            MapIdToBaseId(SportsbookBetTypeIdConstant.FirstNext5Minute, SportsbookBetTypeIdConstant.FirstNext1Minute);

            // Map 'Next 1 Minute Set Piece' to 'What will happen first in next 1 minute'
            MapIdToBaseId(SportsbookBetTypeIdConstant.Next1MinuteSetPiece, SportsbookBetTypeIdConstant.FirstNext1Minute);

            // Map 'Which combination will happen first in next 1 min' to 'What will happen first in next 1 minute'
            MapIdToBaseId(SportsbookBetTypeIdConstant.CombinationNext1Min, SportsbookBetTypeIdConstant.FirstNext1Minute);

            // Map 'Which combination will happen first in next 5 mins' to 'What will happen first in next 1 minute'
            MapIdToBaseId(SportsbookBetTypeIdConstant.CombinationNext5Min, SportsbookBetTypeIdConstant.FirstNext1Minute);
        }

        private void MapForCorrectScore()
        {
            // 30 1H Correct Score
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HCorrectScore, SportsbookBetTypeIdConstant.CorrectScore);

            MapIdToBaseId(SportsbookBetTypeIdConstant.CorrectScoreAOS, SportsbookBetTypeIdConstant.CorrectScore);

            MapIdToBaseId(SportsbookBetTypeIdConstant._1HCorrectScoreAOS, SportsbookBetTypeIdConstant.CorrectScore);

            MapIdToBaseId(SportsbookBetTypeIdConstant._2HCorrectScore, SportsbookBetTypeIdConstant.CorrectScore);
        }

        private void MapForBasketBall()
        {
            // FT Which team to score the first basket (604)
            MapIdToBaseId(SportsbookBetTypeIdConstant.TeamScoreFirstBasket, SportsbookBetTypeIdConstant.TeamScoreHighestQuarter);

            // FT Which team to score the last basket (605)
            MapIdToBaseId(SportsbookBetTypeIdConstant.TeamScoreLastBasket, SportsbookBetTypeIdConstant.TeamScoreHighestQuarter);

            // 2H Race to X Points (607)
            MapIdToBaseId(SportsbookBetTypeIdConstant._2HRaceToXPoints, SportsbookBetTypeIdConstant.TeamScoreHighestQuarter);

            // Quarter X Race to YY  Points (613)
            MapIdToBaseId(SportsbookBetTypeIdConstant.QuarterXRaceToYPoints, SportsbookBetTypeIdConstant.TeamScoreHighestQuarter);

            // Quarter X Home Team Over Under (615)
            MapIdToBaseId(SportsbookBetTypeIdConstant.QuarterXHomeTeamOverUnder, SportsbookBetTypeIdConstant.QuarterXOverUnder);

            // Quarter X Away Team Over Under (616)
            MapIdToBaseId(SportsbookBetTypeIdConstant.QuarterXAwayTeamOverUnder, SportsbookBetTypeIdConstant.QuarterXOverUnder);

            // Quarter X Which team to score the last basket (617)
            MapIdToBaseId(SportsbookBetTypeIdConstant.QuarterXTeamScoreLastBasket, SportsbookBetTypeIdConstant.TeamScoreHighestQuarter);
        }

        private void MapForOddEven()
        {
            // 30 1H Correct Score
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HOddEven, SportsbookBetTypeIdConstant.OddEven);
        }

        private void MapForPH4B()
        {
            MapIdToBaseId(SportsbookBetTypeIdConstant.CornersOddEvenOwn, SportsbookBetTypeIdConstant.FirstHalfHomeTeamOddEven);
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HCornersOddEvenOwn, SportsbookBetTypeIdConstant.FirstHalfHomeTeamOddEven);
            MapIdToBaseId(SportsbookBetTypeIdConstant._2HCornersOddEven, SportsbookBetTypeIdConstant.FirstHalfHomeTeamOddEven);

            MapIdToBaseId(SportsbookBetTypeIdConstant._1HTotalCornersOwn, SportsbookBetTypeIdConstant.TotalCorners);
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HAlternativeCorners, SportsbookBetTypeIdConstant.AlternativeCorners);
            MapIdToBaseId(SportsbookBetTypeIdConstant.Corner3WayHandicap, SportsbookBetTypeIdConstant._3WayHandicap);
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HCorner3WayHandicap, SportsbookBetTypeIdConstant._3WayHandicap);
            MapIdToBaseId(SportsbookBetTypeIdConstant.TimeOf2HFirstCorner, SportsbookBetTypeIdConstant.TimeOfFirstCorner);

            MapIdToBaseId(SportsbookBetTypeIdConstant.AwayTeamCornersOverUnder, SportsbookBetTypeIdConstant.HomeTeamCornersOverUnder);
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HHomeTeamCornersOverUnder, SportsbookBetTypeIdConstant.HomeTeamCornersOverUnder);
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HAwayTeamCornersOverUnder, SportsbookBetTypeIdConstant.HomeTeamCornersOverUnder);
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HCornersRace, SportsbookBetTypeIdConstant.CornersRace);

            MapIdToBaseId(SportsbookBetTypeIdConstant._1HFirstCorner2Way, SportsbookBetTypeIdConstant.FirstCorner2Way);
            MapIdToBaseId(SportsbookBetTypeIdConstant._2HFirstCorner2Way, SportsbookBetTypeIdConstant.FirstCorner2Way);
            MapIdToBaseId(SportsbookBetTypeIdConstant.LastCorner2Way, SportsbookBetTypeIdConstant.FirstCorner2Way);
            MapIdToBaseId(SportsbookBetTypeIdConstant._1HLastCorner2Way, SportsbookBetTypeIdConstant.FirstCorner2Way);

            MapIdToBaseId(SportsbookBetTypeIdConstant._2HCorrectCorners, SportsbookBetTypeIdConstant._1HCorrectCorners);
            MapIdToBaseId(SportsbookBetTypeIdConstant.CornerHighestScoringHalf2Way, SportsbookBetTypeIdConstant.HighestScoringHalf2Way);
        }
    }
}
