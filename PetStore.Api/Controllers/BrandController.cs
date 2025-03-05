using Microsoft.AspNetCore.Mvc;
using PetStore.Business.Services;
using PetStore.Data.Dtos;

namespace PetStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }


        [HttpPost("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var brand = await brandService.CreateBrandAsync(createBrandDto);

            if (brand == null)
            {
                return NotFound(new { message = "Brand failed to create!" });
            }

            return Ok(brand);
        }

        [HttpGet("GetBrandById")]
        public async Task<IActionResult> GetBrandById(int brandId)
        {
            var brand = await this.brandService.GetBrandByIdAsync(brandId);

            if (brand == null)
            {
                return NotFound(new { message = "Cannot find brand" });
            }

            return Ok(brand);
        }

        [HttpGet("GetAllBrands")]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await this.brandService.GetAllBrandsAsync();

            return Ok(brands);
        }
    }
}
