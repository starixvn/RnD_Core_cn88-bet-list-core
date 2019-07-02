namespace CN88.BetList.Core.Utils
{
    public static class Formatters
    {
        public static string ToHandicap(this decimal value)
            => value.ToString("0.#");
    }
}