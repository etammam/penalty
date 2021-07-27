using System.Collections.Generic;

namespace Penalty.Integration.Exchange.Models
{
    public class ExchangeModel
    {
        public double Amount { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }
        public Dictionary<string,double> Rates { get; set; }
    }
}