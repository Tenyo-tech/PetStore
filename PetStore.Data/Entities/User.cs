using System.ComponentModel.DataAnnotations;

namespace PetStore.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataValidation.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DataValidation.EmailMaxLength)]
        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
