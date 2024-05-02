using PETS_API.Data;
using PETS_API.Infra;
using PETS_API.Model;

namespace PETS_API.Repository
{
    public class PetRepository : IPetRepository
    {
        private readonly ApiDbContext _context = new();

        public void Add(Pet pet)
        {
            _context.Pets.Add(pet); 
            _context.SaveChanges();
        }

        public List<Pet> Get()
        {
            return _context.Pets.ToList();
        }

        public Pet GetById(int id)
        {
            var pet = _context.Pets.Find(id);

            return pet;
        }
    }
}
