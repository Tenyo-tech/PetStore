using System.ComponentModel.DataAnnotations;

namespace PetStore.Data.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataValidation.NameMaxLength)]
        public string Name { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<Toy> Toys { get; set; } = new HashSet<Toy>();

        public ICollection<Food> Food { get; set; } = new HashSet<Food>();
    }
}
