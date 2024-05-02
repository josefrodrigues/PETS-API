using PETS_API.Data;

namespace PETS_API.Model
{
    public interface IPetRepository
    {
        void Add(Pet pet);

        List<Pet> Get();

        Pet GetById(int id);

    }
}
