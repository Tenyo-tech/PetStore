using PetStore.Business.Services;
using PetStore.Data.Dtos.Practice;
using PetStore.Data.Repositories;

namespace PetStore.Infrastructure.Services
{
    public class PracticeService : IPracticeService
    {
        public int counterNoLock = 0;

        private static int counter = 0;
        private static object counterLock = new object();


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

        public async Task<object> PracticeConcurrencyAsync()
        {
            // Concurrency Example
            // Start two independent async operations without awaiting them immediately.
            // This allows both to progress at the same time (concurrency).
            // It switches between them when one is waiting (like I/O, delays).

            //Concurrency is not the same as parallelism.

            //Parallelism
            //Doing two things at the exact same time
            //(using two CPU cores).

            //Concurrency
            //Switching between tasks quickly so they are progressing together.

            var foodsTask = practiceRepository.GetAllFoodsAsync();   // starts fetching foods
            var toysTask = practiceRepository.GetAllToysAsync();     // starts fetching toys

            // await Task.WhenAll waits for both tasks to complete.
            // Because we started both before awaiting, their work overlaps (concurrency).
            // From your perspective both are running together.
            await Task.WhenAll(foodsTask, toysTask);

            return new
            {
                Foods = await foodsTask,
                Toys = await toysTask
            };
        }

        public async Task PracticeAsyncVoidAsync()
        {
            // ? async void is DANGEROUS and should almost NEVER be used.
            // This method demonstrates the problem and the solution with comments.

            // Why async void is bad:
            // 1) Exceptions thrown inside async void methods cannot be caught by the caller.
            //    If an exception happens, it will crash the whole application.
            // 2) The caller has no way to know when the async void method finishes.
            //    Fire-and-forget operations make debugging harder.
            // 3) You cannot await async void methods.

            // ? WRONG - NEVER DO THIS (unless it's an event handler like button click):
            // async void BadMethod()
            // {
            //     await Task.Delay(1000);
            //     throw new Exception("This will CRASH the app!");  // No one can catch this!
            // }

            // ? CORRECT - Always use async Task instead:
            // async Task GoodMethod()
            // {
            //     await Task.Delay(1000);
            //     throw new Exception("This can be caught by the caller.");  // Safe!
            // }

            // This method returns Task (correct approach).
            // The caller CAN await it and handle exceptions properly.

            await Task.Delay(500);

            var allFoods = await practiceRepository.GetAllFoodsAsync();
            var foodCount = allFoods.Count();

            // Safe: exceptions here can be caught, and caller knows when it completes.
        }


        void IncreaseCounter()
        {
            counterNoLock++; // not atomic
        }

        static void IncreaseCounter()
        {
            lock (counterLock) // only one thread can enter here at a time
            {
                counter++;
                Console.WriteLine($"Counter: {counter}");
            }
        }
    }
}
