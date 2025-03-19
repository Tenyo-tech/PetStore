using System.ComponentModel.DataAnnotations;

namespace PetStore.Data.Entities
{
    public class Toy
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataValidation.NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(DataValidation.DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        public decimal DistributorPrice { get; set; }

        public decimal Price { get; set; }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<ToyOrder> Orders { get; set; } = new HashSet<ToyOrder>();
    }
}
