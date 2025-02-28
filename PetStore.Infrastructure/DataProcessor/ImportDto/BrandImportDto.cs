using PetStore.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Infrastructure.DataProcessor.ImportDto
{
    public class BrandImportDto
    {

        [Required]
        [MaxLength(DataValidation.NameMaxLength)]
        public string Name { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}
