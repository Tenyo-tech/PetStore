using System.ComponentModel.DataAnnotations;

namespace PetStore.Data.Dtos.Order
{
    public class CreateOrderDto
    {
        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public int UserId { get; set; }

        public List<int> PetIds { get; set; } = new List<int>(); // List of Pet IDs

        public List<int> FoodIds { get; set; } = new List<int>(); // List of Food IDs

        public List<int> ToyIds { get; set; } = new List<int>(); // List of Toy IDs
    }
}
