using Microsoft.EntityFrameworkCore;
using PETS_API.Data;

namespace PETS_API.Infra
{

    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DBPets;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Pet> Pets { get; set; }

    }
}
