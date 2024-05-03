using PETS_API.Domain.DTOs;
using PETS_API.Domain.Models.PetAggregate;

namespace PETS_API.Infra.Repository
{
    public class PetRepository : IPetRepository
    {
        private readonly ApiDbContext _context = new();

        public void Add(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
        }

        public List<PetDTO> Get(int pageNumber, int pageQuantity)
        {
            return _context.Pets.Skip(pageNumber * pageQuantity)
                .Take(pageQuantity)
                .Select(pet =>
                new PetDTO()
                {
                    id = pet.id,
                    PetName = pet.Name,
                    Race = pet.Race,
                    Photo = pet.Photo
                }).ToList();
        }

        public Pet? GetById(int id)
        {
            var pet = _context.Pets.Find(id);

            return pet;
        }
    }
}
