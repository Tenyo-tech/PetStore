using Microsoft.AspNetCore.Mvc;
using PetStore.Business.Services;
using PetStore.Data.Dtos.Toy;

namespace PetStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToysController : ControllerBase
    {
        private readonly IToyService toyService;

        public ToysController(IToyService toyService)
        {
            this.toyService = toyService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetToyById(int id)
        {
            var toy = await toyService.GetToyByIdAsync(id);
            if (toy == null)
                return NotFound(new { message = "Cannot find toy" });

            return Ok(toy);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllToys()
        {
            var toys = await toyService.GetAllToysAsync();
            return Ok(toys);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToy(CreateToyDto createToyDto)
        {
            var toy = await toyService.CreateToyAsync(createToyDto);
            return Ok(toy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToy(int id, UpdateToyDto updateToyDto)
        {
            var toy = await toyService.UpdateToyAsync(id, updateToyDto);
            return Ok(new { Message = "Toy updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToy(int id)
        {
            var toy = await toyService.DeleteToyAsync(id);
            return Ok(new { Message = "Toy deleted successfully" });
        }
    }
}
