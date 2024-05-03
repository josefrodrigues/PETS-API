using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PETS_API.Domain.Models.OwnerAggregate
{
    [Table("Owners")]
    public class Owner
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }
    }
}
