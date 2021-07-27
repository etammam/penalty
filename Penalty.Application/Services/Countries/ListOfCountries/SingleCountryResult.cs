using AutoMapper;
using Penalty.Application.Common.Mappings;
using Penalty.Domain.Entities;

namespace Penalty.Application.Services.Countries.ListOfCountries
{
    public class SingleCountryResult : IMapFrom<Domain.Entities.Penalty>
    {
        public string Id { get; set; }
        public string Country { get; set; }
        public string NativeName { get; set; }
        public string[] AltSpellings { get; set; }
        public string Currency { get; set; }
        public double Fine { get; set; }
        public string[] Holidays { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Penalty, SingleCountryResult>()
                .ReverseMap();
        }
    }
}
