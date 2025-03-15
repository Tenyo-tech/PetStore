namespace PetStore.Data.Dtos.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
