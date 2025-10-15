using Microsoft.AspNetCore.Mvc;
using PetStore.Business.Services;
using PetStore.Data.Dtos.Breed;

namespace PetStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreedController : ControllerBase
    {
        private readonly IBreedService breedService;

        public BreedController(IBreedService breedService)
        {
            this.breedService = breedService;
        }

        // GET /api/breeds/{id} → Gets a breed by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBreedById(int id)
        {
            var breed = await this.breedService.GetBreedByIdAsync(id);
            if (breed == null)
                return NotFound(new { message = "Cannot find breed" });

            return Ok(breed);
        }

        // GET /api/breeds → Returns all breeds
        [HttpGet]
        public async Task<IActionResult> GetBreeds()
        {
            var breeds = await this.breedService.GetAllBreedsAsync();
            return Ok(breeds);
        }

        // POST /api/breeds → Creates a new breed
        [HttpPost]
        public async Task<IActionResult> CreateBreed(CreateBreedDto createBreedDto)
        {
            var breed = await breedService.CreateBreedAsync(createBreedDto);
            if (breed == null)
                return BadRequest(new { message = "Breed creation failed!" });

            return Ok(breed);
        }

        // PUT /api/breeds/{id} → Updates an existing breed
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBreed(int id, UpdateBreedDto breedDto)
        {
            var breed = await this.breedService.UpdateBreedAsync(id, breedDto);
            if (breed == null)
                return NotFound(new { message = "Cannot find breed" });

            return Ok(new { Message = "Breed updated successfully" });
        }

        // DELETE /api/breeds/{id} → Deletes a breed by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreed(int id)
        {
            var breed = await this.breedService.DeleteBreedAsync(id);
            if (breed == null)
                return NotFound(new { message = "Cannot find breed" });

            return Ok(new { Message = "Breed deleted successfully" });
        }
    }
}
