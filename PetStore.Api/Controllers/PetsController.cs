using Microsoft.AspNetCore.Mvc;
using PetStore.Business.Services;
using PetStore.Data.Dtos.Pet;

namespace PetStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService petService;

        public PetsController(IPetService petService)
        {
            this.petService = petService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPetById(int id)
        {
            var pet = await petService.GetPetByIdAsync(id);
            if (pet == null)
                return NotFound(new { message = "Cannot find pet" });

            return Ok(pet);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPets()
        {
            var pets = await petService.GetAllPetsAsync();
            return Ok(pets);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePet(CreatePetDto createPetDto)
        {
            var pet = await petService.CreatePetAsync(createPetDto);
            return Ok(pet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(int id, UpdatePetDto updatePetDto)
        {
            var pet = await petService.UpdatePetAsync(id, updatePetDto);
            return Ok(new { Message = "Pet updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await petService.DeletePetAsync(id);
            return Ok(new { Message = "Pet deleted successfully" });
        }
    }
}
