using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PETS_API.Application.RequestModels;
using PETS_API.Domain.DTOs;
using PETS_API.Domain.Models.PetAggregate;

namespace PETS_API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;
        private readonly ILogger<PetController> _logger;
        private readonly IMapper _mapper;

        public PetController(IPetRepository petRepository, ILogger<PetController> logger, IMapper mapper)
        {
            _petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize]
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

        [Authorize]
        [HttpPost("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var pet = _petRepository.GetById(id);

            var dataBytes = System.IO.File.ReadAllBytes(pet.Photo);

            return File(dataBytes, "image/png");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {

            var pets = _petRepository.Get(pageNumber, pageNumber);

            return Ok(pets);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Search(int id)
        {
            _logger.LogInformation("Testando Mapper");
            var pet = _petRepository.GetById(id);

            var petDTO = _mapper.Map<PetDTO>(pet);

            return Ok(petDTO);
        }
    }
}
