using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PETS_API.Domain.Models.PetAggregate
{

    [Table("Pets")]
    public class Pet
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
        public string? Photo { get; set; }

        public Pet() { }
        public Pet(string name, string race, int age, string? photo)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Race = race;
            Age = age;
            Photo = photo;
        }
    }
}
