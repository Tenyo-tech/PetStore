using PetStore.Business.Services;
using PetStore.Data.Dtos.Practice;
using PetStore.Data.Repositories;
using System.Threading.Tasks;

namespace PetStore.Infrastructure.Services
{
    public class PracticeService : IPracticeService
    {
        private readonly IPracticeRepository practiceRepository;

        public PracticeService(IPracticeRepository practiceRepository)
        {
            this.practiceRepository = practiceRepository;
        }

        public string GetMessage()
        {
            return practiceRepository.GetMessage();
        }

        public async Task<PracticeResultDto> PracticeTasksAsync()
        {
            return await practiceRepository.PracticeTasksAsync();
        }

        public PracticeResultDto PracticeThreads()
        {
            return practiceRepository.PracticeThreads();
        }
    }
}
