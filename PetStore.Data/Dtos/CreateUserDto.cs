using System.ComponentModel.DataAnnotations;
using static PetStore.Data.Entities.DataValidation;

namespace PetStore.Data.Dtos
{
    public class CreateUserDto
    {

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; } = string.Empty;
    }
}
