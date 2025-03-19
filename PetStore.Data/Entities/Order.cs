namespace PetStore.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        public OrderStatus Status { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }  // ✅ Lazy Loading Enabled

        public virtual ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();  // ✅ Lazy Loading Enabled

        public virtual ICollection<FoodOrder> Food { get; set; } = new HashSet<FoodOrder>();  // ✅ Lazy Loading Enabled

        public virtual ICollection<ToyOrder> Toys { get; set; } = new HashSet<ToyOrder>();  // ✅ Lazy Loading Enabled
    }
}
