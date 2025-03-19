using PetStore.Data.Dtos.Food;
using PetStore.Data.Dtos.Pet;
using PetStore.Data.Dtos.Toy;

namespace PetStore.Data.Dtos.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int UserId { get; set; }

        public List<PetDto> Pets { get; set; } = new List<PetDto>();
        public List<FoodDto> Foods { get; set; } = new List<FoodDto>();
        public List<ToyDto> Toys { get; set; } = new List<ToyDto>();
    }
}
