namespace PetStore.Data.DataProcessor
{
    public interface IDeserializer
    {
        public Task<string> ImportBrand();
        public Task<string> ImportBreed();
        public Task<string> ImportCategory();
        public Task<string> ImportFood();
        public Task<string> ImportPet();
        public Task<string> ImportToy();

        public Task<string> ImportConfig();
    }
}
