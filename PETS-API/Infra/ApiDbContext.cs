using Microsoft.EntityFrameworkCore;
using PETS_API.Domain.Models.OwnerAggregate;
using PETS_API.Domain.Models.PetAggregate;

namespace PETS_API.Infra
{

    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=master;User Id=SA;Password=Abc$1234;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

    }
}
