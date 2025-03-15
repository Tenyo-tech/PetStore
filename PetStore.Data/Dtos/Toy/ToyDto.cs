namespace PetStore.Data.Dtos.Toy
{
    public class ToyDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal DistributorPrice { get; set; }

        public decimal Price { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }
    }
}
