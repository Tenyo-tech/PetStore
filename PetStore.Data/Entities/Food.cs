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

        public string ImageUrl { get; set; } = string.Empty;

        // In KG.
        public double Weight { get; set; }

        public Metric Metric { get; set; }

        public decimal DistributorPrice { get; set; }

        public decimal Price { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<FoodOrder> Orders { get; set; } = new HashSet<FoodOrder>();
    }
}
