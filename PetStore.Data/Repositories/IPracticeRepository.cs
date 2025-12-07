using PetStore.Data.Dtos.Practice;
using System.Threading.Tasks;

namespace PetStore.Data.Repositories
{
    public interface IPracticeRepository
    {
        string GetMessage();
        Task<PracticeResultDto> PracticeTasksAsync();
        PracticeResultDto PracticeThreads();
    }
}
