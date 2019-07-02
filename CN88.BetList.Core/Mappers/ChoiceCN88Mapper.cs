namespace CN88.BetList.Core.Mappers
{
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
        }

        private void MapForHandicap()
        {
            // 7 1H Handicap
            MapIdToBaseId(7, 1);

            // 17 2H Handicap
            MapIdToBaseId(17, 1);

            // 153 FT. Game HDP
            MapIdToBaseId(153, 1);

            // 155 Set x Game Handicap
            MapIdToBaseId(155, 1);

            // 609 Quarter X Handicap
            MapIdToBaseId(609, 1);

            // 9002 Map X Total Kills Handicap
            MapIdToBaseId(9002, 1);

            // 9008 Map X Total Towers Handicap
            MapIdToBaseId(9008, 1);
            // 9012 Map X Total Roshans Handicap
            MapIdToBaseId(9012, 1);
            // 9018 Map X Total Barracks Handicap
            MapIdToBaseId(9018, 1);
            // 9024 Map X Total Turrets Handicap
            MapIdToBaseId(9024, 1);
            // 9028 Map X Total Dragons Handicap
            MapIdToBaseId(9028, 1);
            // 9034 Map X Total Barons Handicap
            MapIdToBaseId(9034, 1);
            // 9040 Map X Total Inhibitors Handicap
            MapIdToBaseId(9040, 1);
            // 9046 Map X Total Tyrants Handicap
            MapIdToBaseId(9046, 1);
            // 9052 Map X Total Overlords Handicap
            MapIdToBaseId(9052, 1);
            // 9059 Map X Rounds Handicap
            MapIdToBaseId(9059, 1);
            // 9076 Map X Clutches Handicap
            MapIdToBaseId(9076, 1);
            // 9077 Map X Round Y Total Kills Handicap
            MapIdToBaseId(9077, 1);
        }

        private void MapForOverUnder()
        {
            // 8 1H Over/Under
            MapIdToBaseId(8, 3);
            //18 2H Over/Under
            MapIdToBaseId(18, 3);
            //156 Set x Total Game Over/Under
            MapIdToBaseId(156, 3);
            //461 Home Team Over/Under (dec)
            MapIdToBaseId(461, 3);
            //462 AwayTeam Over/Under (dec)
            MapIdToBaseId(462, 3);
            //463 1H Home Team Over/Under (dec)
            MapIdToBaseId(463, 3);
            //464 1H AwayTeam Over/Under (dec)
            MapIdToBaseId(464, 3);
            //601 FT Winning Margin 14 Way
            MapIdToBaseId(601, 3);
            //602 FT Winning Margin 12 Way
            MapIdToBaseId(602, 3);
            //610 Quarter X Over/Under
            MapIdToBaseId(610, 3);

            //615 Quarter X Home Team Over / Under
            MapIdToBaseId(615, 3);
            //616 Quarter X Away Team Over / Under
            MapIdToBaseId(616, 3);
            //9003 Map X Total Kills Over/Under
            MapIdToBaseId(9003, 3);
            //9009 Map X Total Towers Over/Under
            MapIdToBaseId(9009, 3);
            //9013 Map X Total Roshans Over/Under
            MapIdToBaseId(9013, 3);
            //9019 Map X Total Barracks Over/Under
            MapIdToBaseId(9019, 3);
            //9025 Map X Total Turrets Over/Under
            MapIdToBaseId(9025, 3);
            //9029 Map X Total Dragons Over/Under
            MapIdToBaseId(9029, 3);
            //9035 Map X Total Barons Over/Under
            MapIdToBaseId(9035, 3);
            //9041 Map X Total Inhibitors Over/Under
            MapIdToBaseId(9041, 3);
            //9047 Map X Total Tyrants Over/Under
            MapIdToBaseId(9047, 3);
            //9053 Map X Total Overlords Over/Under
            MapIdToBaseId(9053, 3);
            //9058 Map X Duration Over/Under (Mins)
            MapIdToBaseId(9058, 3);
            //9060 Map X Rounds Over/Under
            MapIdToBaseId(9060, 3);
            //9070 Map X Round Y Total Kills Over/Under
            MapIdToBaseId(9070, 3);
            //9074 Map X Rounds Over/Under (Overtime)
            MapIdToBaseId(9074, 3);
        }

        private void MapForCorrectScore()
        {
            // 30 1H Correct Score
            MapIdToBaseId(30, 4);
        }
    }
}