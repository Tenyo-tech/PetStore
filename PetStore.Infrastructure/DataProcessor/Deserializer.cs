using Newtonsoft.Json;
using PetStore.Data.Context;
using PetStore.Data.DataProcessor;
using PetStore.Data.Entities;
using PetStore.Infrastructure.DataProcessor.ImportDto;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Infrastructure.DataProcessor
{
    public class Deserializer : IDeserializer
    {
        private string baseDir = "";
        private readonly IPetStoreDbContext petStoreDbContext;

        public Deserializer(IPetStoreDbContext petStoreDbContext)
        {
            this.petStoreDbContext = petStoreDbContext;
        }
        public async Task<string> ImportBrand()
        {
            var jsonString = GetJsonString("BrandInput.json");
            var brands = JsonConvert.DeserializeObject<IEnumerable<BrandImportDto>>(jsonString);

            foreach (var dto in brands)
            {
                if (IsValid(dto))
                {
                    var brand = new Brand()
                    {
                        Name = dto.Name,
                        ImageUrl = dto.ImageUrl
                    };

                    petStoreDbContext.Brands.Add(brand);
                }
            }

            await petStoreDbContext.SaveChangesAsync();

            return jsonString;
        }


        public async Task<string> ImportBreed()
        {
            var jsonString = GetJsonString("BreedInput.json");
            var breeds = JsonConvert.DeserializeObject<IEnumerable<BreedImportDto>>(GetJsonString("BreedInput.json"));

            foreach (var dto in breeds)
            {
                if (IsValid(dto))
                {
                    var breed = new Breed()
                    {
                        Name = dto.Name,
                    };

                    petStoreDbContext.Breeds.Add(breed);
                }
            }

            await petStoreDbContext.SaveChangesAsync();

            return jsonString;
        }

        public async Task<string> ImportCategory()
        {
            var jsonString = GetJsonString("CategoryInput.json");
            var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryInputDto>>(jsonString);

            foreach (var dto in categories)
            {
                if (IsValid(dto))
                {
                    var category = new Category()
                    {
                        Name = dto.Name,
                    };

                    petStoreDbContext.Categories.Add(category);
                }
            }

            await petStoreDbContext.SaveChangesAsync();

            return jsonString;
        }

        public async Task<string> ImportFood()
        {
            var jsonString = GetJsonString("FoodInput.json");
            var foods = JsonConvert.DeserializeObject<IEnumerable<FoodInputDto>>(jsonString);

            foreach (var dto in foods)
            {
                if (IsValid(dto))
                {
                    var food = new Food()
                    {
                        Name = dto.Name,
                        Weight = dto.Weight,
                        DistributorPrice = dto.DistributorPrice,
                        Price = dto.Price,
                        ExpirationDate = dto.ExpirationDate,
                        BrandId = dto.BrandId,
                        CategoryId = dto.CategoryId,
                    };

                    petStoreDbContext.Food.Add(food);
                }
            }

            await petStoreDbContext.SaveChangesAsync();

            return jsonString;
        }

        public async Task<string> ImportPet()
        {
            var jsonString = GetJsonString("PetInput.json");
            var pets = JsonConvert.DeserializeObject<IEnumerable<PetInputDto>>(jsonString);

            foreach (var dto in pets)
            {
                if (IsValid(dto))
                {
                    var pet = new Pet()
                    {
                        Gender = dto.Gender,
                        DateOfBirth = dto.DateOfBirth,
                        Price = dto.Price,
                        Description = dto.Description,
                        BreedId = dto.BreedId,
                        CategoryId = dto.CategoryId
                    };

                    petStoreDbContext.Pets.Add(pet);
                }
            }

            await petStoreDbContext.SaveChangesAsync();

            return jsonString;
        }

        public async Task<string> ImportToy()
        {
            var jsonString = GetJsonString("ToyInput.json");
            var toys = JsonConvert.DeserializeObject<IEnumerable<ToyInputDto>>(jsonString);

            foreach (var dto in toys)
            {
                if (IsValid(dto))
                {
                    var toy = new Toy()
                    {
                        Name = dto.Name,
                        Description = dto.Description,
                        DistributorPrice = dto.DistributorPrice,
                        Price = dto.Price,
                        BrandId = dto.BrandId,
                        CategoryId = dto.CategoryId
                    };

                    petStoreDbContext.Toys.Add(toy);
                }
            }

            await petStoreDbContext.SaveChangesAsync();

            return jsonString;
        }

        private string GetJsonString(string filename)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var solutionDirectory = Directory.GetParent(currentDirectory)?.FullName;

            if (solutionDirectory == null)
                throw new Exception("Solution directory not found");

            var jsonFilePath = Path.Combine(solutionDirectory, "PetStore.Infrastructure", "DataProcessor", "DataSets", filename);
            var jsonFile = File.ReadAllText(jsonFilePath);

            return jsonFile;
        }

        private bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var res = Validator.TryValidateObject(obj, validator, validationRes, validateAllProperties: true);
            return res;
        }
    }
}
