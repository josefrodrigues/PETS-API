using PETS_API.Domain.DTOs;

namespace PETS_API.Domain.Models.PetAggregate
{
    public interface IPetRepository
    {
        void Add(Pet pet);

        List<PetDTO> Get(int pageNumber, int pageQuantity);

        Pet GetById(int id);

    }
}
