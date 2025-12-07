using PetStore.Data.Dtos.Practice;
using PetStore.Data.Dtos.Food;
using PetStore.Data.Dtos.Toy;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PetStore.Data.Repositories
{
    public interface IPracticeRepository
    {
        string GetMessage();
        Task<PracticeResultDto> PracticeTasksAsync();
        PracticeResultDto PracticeThreads();
        Task<IEnumerable<FoodDto>> GetAllFoodsAsync();
        Task<IEnumerable<ToyDto>> GetAllToysAsync();
        Task PracticeAsyncVoidAsync();
    }
}
