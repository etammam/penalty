using System;

namespace Penalty.Application.Services.Penalties.ApplyingBusinessPenalty
{
    public class ApplyingBusinessPenaltyResult
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Country { get; set; }
        public string[] Holidays { get; set; }
        public double FineInUsd { get; set; }
        public string Currency { get; set; }
        public double ExchangedValue { get; set; }
        public int CountedBusinessDays { get; set; }
        public double PenaltyValue { get; set; }
    }
}
