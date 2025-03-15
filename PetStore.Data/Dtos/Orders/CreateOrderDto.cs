using System.ComponentModel.DataAnnotations;

namespace PetStore.Data.Dtos.Order
{
    public class CreateOrderDto
    {
        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
