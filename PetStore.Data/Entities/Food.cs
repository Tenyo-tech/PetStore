using System.ComponentModel.DataAnnotations;

namespace PetStore.Data.Entities
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataValidation.NameMaxLength)]
        public string Name { get; set; }

        // In KG.
        public double Weight { get; set; }

        public decimal DistributorPrice { get; set; }

        public decimal Price { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<FoodOrder> Orders { get; set; } = new HashSet<FoodOrder>();
    }
}
