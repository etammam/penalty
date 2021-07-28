namespace Penalty.APIs.Setups.Bases
{
    public static class Router
    {
        private const string Version = "v1";
        private const string Root = "apis";
        private const string Rule = Version + "/" + Root + "/";
        public class Country
        {
            private const string Prefix = Rule + "countries";
            public const string GetListOfCountries = Prefix;
        }

        public class Currencies
        {
            private const string Prefix = Rule + "currencies";
            public const string GetSupportedCurrencies = Prefix;
            public const string IsCurrencySupported = Prefix + "/is-currency-supported/{currencyCode}";
            public const string Exchange = Prefix + "/exchange";
        }
        
        public class PenaltyCalculator
        {
            private const string Prefix = Rule+"penalty";
            public const string CountBusinessDays = Prefix + "/count-business-days";
            public const string ApplyingPenaltyValue = Prefix + "/apply-penalty";
        }
    }
}
