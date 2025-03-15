using Microsoft.AspNetCore.Mvc;
using PetStore.Business.Services;
using PetStore.Data.Dtos.Brand;

namespace PetStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        // GET /api/brands/{id} → Gets a brand by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var brand = await this.brandService.GetBrandByIdAsync(id);

            if (brand == null)
            {
                return NotFound(new { message = "Cannot find brand" });
            }

            return Ok(brand);
        }

        // GET /api/brands → Returns all brands
        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await this.brandService.GetAllBrandsAsync();

            return Ok(brands);
        }

        // POST /api/brands → Creates a new brand
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var brand = await brandService.CreateBrandAsync(createBrandDto);

            if (brand == null)
            {
                return NotFound(new { message = "Brand failed to create!" });
            }

            return Ok(brand);
        }

        // PUT /api/brands/{id} → Updates an existing brand
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, UpdateBrandDto brandDto)
        {
            var brand = await this.brandService.UpdateBrandAsync(id, brandDto);

            if (brand == null)
            {
                return NotFound(new { message = "Cannot find brand" });
            }

            return Ok(new { Message = "Brand updated successfully" });
        }

        // DELETE /api/brands/{id} → Deletes a brand by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await this.brandService.DeleteBrandAsync(id);

            if (brand == null)
            {
                return NotFound(new { message = "Cannot find brand" });
            }

            return Ok(new { Message = "Brand deleted successfully" });
        }
    }
}
