using PetStore.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Data.Dtos.Order
{
    public class UpdateOrderDto
    {
        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public OrderStatus Status { get; set; }
    }
}
