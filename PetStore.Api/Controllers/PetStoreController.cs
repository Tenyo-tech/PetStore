using Microsoft.AspNetCore.Mvc;
using PetStore.Data.DataProcessor;
namespace PetStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetStoreController : ControllerBase
    {
        private readonly IDeserializer deserializer;

        public PetStoreController(IDeserializer deserializer)
        {
            this.deserializer = deserializer;
        }

        [HttpGet("GetString")]
        public IEnumerable<string> GetString()
        {
            return new[] { "asd", "asd" };
        }

        [HttpPost("ImportData")]
        public async Task<IActionResult> ImportData()
        {
            //var brands = await deserializer.ImportBrand();
            //var breeds = await deserializer.ImportBreed();
            //var categories = await deserializer.ImportCategory();
            //var food = await deserializer.ImportFood();
            //var pets = await deserializer.ImportPet();
            //var toys = await deserializer.ImportToy();
            return Ok();
        }
    }
}
