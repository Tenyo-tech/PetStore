using PetStore.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Data.Dtos.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataValidation.NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(DataValidation.DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;
    }
}
