using System.ComponentModel.DataAnnotations;

namespace PetStore.Data.Entities
{
    public class Breed
    {
        //[Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataValidation.NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public virtual ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();
    }
}
