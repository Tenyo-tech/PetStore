using PetStore.Data.Dtos.Practice;
using System.Threading.Tasks;

namespace PetStore.Business.Services
{
    public interface IPracticeService
    {
        string GetMessage();
        Task<PracticeResultDto> PracticeTasksAsync();
        PracticeResultDto PracticeThreads();
        Task<object> PracticeConcurrencyAsync();
        Task PracticeAsyncVoidAsync();
    }
}
