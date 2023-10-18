using AutoMapper;
using Tappit.Application.Models.Requests;
using Tappit.Application.Models.Responses;
using Tappit.Domain;

namespace Tappit.Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<NewPersonRequest, Person>();
            CreateMap<Person, PersonResponse>();

            CreateMap<NewSportRequest, Sport>();
            CreateMap<Sport, SportResponse>();

            CreateMap<FavouriteSport, FavouriteSportResponse>();
        }
    }
}
