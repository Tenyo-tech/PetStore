namespace PetStore.Data.Entities
{
    public class FoodOrder
    {
        public int FoodId { get; set; }

        public virtual Food Food { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
