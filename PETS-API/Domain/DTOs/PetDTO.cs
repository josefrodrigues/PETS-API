namespace PETS_API.Domain.DTOs
{
    public class PetDTO
    {
        public int id { get; set; }
        public string PetName { get; set; }
        public string Race { get; set; }

        public string? Photo {  get; set; }

    }
}
