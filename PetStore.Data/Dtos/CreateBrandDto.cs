using PetStore.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Data.Dtos
{
    public class CreateBrandDto
    {
        [Required]
        [MaxLength(DataValidation.NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
