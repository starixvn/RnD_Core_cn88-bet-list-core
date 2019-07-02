namespace CN88.BetList.Core.Builders
{
    using System;
    using System.Collections.Generic;

    public static class CN88KenoUtils
    {
        public static Dictionary<string, string> ParseTransDesc(string transDesc)
        {
            const string GameIdIndicator = "betChoice=";
            int lengthOfNeededInfo = transDesc.IndexOf(';');
            string neededInfo = transDesc.Substring(0, lengthOfNeededInfo < 0 ? transDesc.Length : lengthOfNeededInfo);
            string[] parts = neededInfo.Split(',');

            string choiceId = null;
            string gameId = null;

            if (parts.Length == 2)
            {
                if (parts[0].StartsWith(GameIdIndicator, StringComparison.InvariantCultureIgnoreCase))
                {
                    gameId = parts[0].Substring(parts[0].IndexOf('=') + 1).Trim();
                }

                choiceId = parts[1].Trim();
            }

            return new Dictionary<string, string> { ["gameId"] = gameId, ["choiceId"] = choiceId };
        }
    }
}
