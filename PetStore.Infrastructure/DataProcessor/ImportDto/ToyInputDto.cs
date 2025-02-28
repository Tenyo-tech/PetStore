using System.ComponentModel.DataAnnotations;
using static PetStore.Data.Entities.DataValidation;

namespace PetStore.Infrastructure.DataProcessor.ImportDto
{
    public class ToyInputDto
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public decimal DistributorPrice { get; set; }

        public decimal Price { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }
    }
}
