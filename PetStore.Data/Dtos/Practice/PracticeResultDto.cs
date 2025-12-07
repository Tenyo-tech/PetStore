using PetStore.Data.Dtos.Brand;
using PetStore.Data.Dtos.Food;
using System.Collections.Generic;

namespace PetStore.Data.Dtos.Practice
{
    public class PracticeResultDto
    {
        public BrandDto? Brand { get; set; }
        public IEnumerable<FoodDto> Foods { get; set; } = new List<FoodDto>();
        public long ElapsedMilliseconds { get; set; }
    }
}
