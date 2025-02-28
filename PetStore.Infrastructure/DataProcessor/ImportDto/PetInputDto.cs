using PetStore.Data.Entities;
using System.ComponentModel.DataAnnotations;
using static PetStore.Data.Entities.DataValidation;

namespace PetStore.Infrastructure.DataProcessor.ImportDto
{
    public class PetInputDto
    {
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Price { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public int BreedId { get; set; }

        public int CategoryId { get; set; }
    }
}
