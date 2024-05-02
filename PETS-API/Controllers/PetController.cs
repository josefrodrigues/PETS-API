using Microsoft.AspNetCore.Mvc;
using PETS_API.Data;
using PETS_API.Model;
using PETS_API.RequestModel;

namespace PETS_API.Controllers
{
    [ApiController]
    [Route("api/v1/pet")]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));  
        }

        [HttpPost]
        public IActionResult Add([FromForm] PetRequestModel petRequest)
        {
            var filePath = Path.Combine("Storage", petRequest.Photo.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            petRequest.Photo.CopyTo(fileStream);

            var pet = new Pet(petRequest.Name, petRequest.Race, petRequest.Age, filePath);

            _petRepository.Add(pet);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pets = _petRepository.Get();
            return Ok(pets);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pet = _petRepository.GetById(id);
            return Ok(pet);
        }

        [HttpPost("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var pet = _petRepository.GetById(id);

            var dataBytes = System.IO.File.ReadAllBytes(pet.Photo);

            return File(dataBytes, "image/png");
        }
    }
}
