using PetStore.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Data.Dtos.Category
{
    public class UpdateCategoryDto
    {
        [Required]
        [MaxLength(DataValidation.NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(DataValidation.DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;
    }
}
