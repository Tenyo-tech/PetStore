using PetStore.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Data.Dtos.Category
{
    public class CreateCategoryDto
    {
        [Required]
        [MaxLength(DataValidation.NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(DataValidation.DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;
    }
}
