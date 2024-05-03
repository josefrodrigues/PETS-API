using AutoMapper;
using PETS_API.Domain.DTOs;
using PETS_API.Domain.Models.PetAggregate;

namespace PETS_API.Application.Mapper
{
    public class DomainToDTOMapper : Profile
    {
        public DomainToDTOMapper()
        {
            CreateMap<Pet, PetDTO>()
                .ForMember(dest => dest.PetName, map => map.MapFrom(orig => orig.Name));
        }
    }
}
