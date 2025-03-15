using PetStore.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Data.Dtos.Pet
{
    public class CreatePetDto
    {
        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(DataValidation.DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int BreedId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public int? OrderId { get; set; }
    }
}
