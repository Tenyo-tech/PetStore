using System.ComponentModel.DataAnnotations;
using static PetStore.Data.Entities.DataValidation;
namespace PetStore.Infrastructure.DataProcessor.ImportDto
{
    public class FoodInputDto
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public double Weight { get; set; }

        public decimal DistributorPrice { get; set; }

        public decimal Price { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }
    }
}
