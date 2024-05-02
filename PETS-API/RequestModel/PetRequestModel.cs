namespace PETS_API.RequestModel
{
    public class PetRequestModel
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }

        public IFormFile Photo { get; set; }

    }
}
