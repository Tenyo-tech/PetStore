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
        public string Description { get; set; }

        public ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();

        public ICollection<Toy> Toys { get; set; } = new HashSet<Toy>();

        public ICollection<Food> Food { get; set; } = new HashSet<Food>();
    }
}
