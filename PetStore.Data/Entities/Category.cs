using System.ComponentModel.DataAnnotations;

namespace PetStore.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataValidation.NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DataValidation.DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();

        public virtual ICollection<Toy> Toys { get; set; } = new HashSet<Toy>();

        public virtual ICollection<Food> Food { get; set; } = new HashSet<Food>();
    }
}
