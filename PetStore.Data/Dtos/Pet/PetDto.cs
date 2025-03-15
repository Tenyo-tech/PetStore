namespace PetStore.Data.Dtos.Pet
{
    public class PetDto
    {
        public int Id { get; set; }
        public string Gender { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int BreedId { get; set; }
        public int CategoryId { get; set; }
        public int? OrderId { get; set; }
    }
}
