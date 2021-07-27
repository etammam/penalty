using System;

namespace Penalty.Domain.Entities
{
    public class Penalty
    {
        public Penalty()
        {
            Id = Guid.NewGuid().ToString().Replace("-", string.Empty);
        }
        public string Id { get; set; }
        public string Country { get; set; }
        public string NativeName { get; set; }
        public string[] AltSpellings { get; set; }
        public string Currency { get; set; }
        public double Fine { get; set; }
        public string[] Holidays { get; set; }
    }
}
