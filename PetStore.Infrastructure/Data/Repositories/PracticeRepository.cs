using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetStore.Data.Context;
using PetStore.Data.Dtos.Brand;
using PetStore.Data.Dtos.Food;
using PetStore.Data.Dtos.Practice;
using PetStore.Data.Dtos.Toy;
using PetStore.Data.Repositories;
using System.Diagnostics;

namespace PetStore.Infrastructure.Data.Repositories
{
    public class PracticeRepository : IPracticeRepository
    {
        private readonly IPetStoreDbContext petStoreDbContext;
        private readonly IPetStoreConfigsDbContext petStoreConfigsDbContext;
        private readonly IMapper mapper;

        public PracticeRepository(
            IPetStoreDbContext petStoreDbContext,
            IPetStoreConfigsDbContext petStoreConfigsDbContext,
            IMapper mapper)
        {
            this.petStoreDbContext = petStoreDbContext;
            this.petStoreConfigsDbContext = petStoreConfigsDbContext;
            this.mapper = mapper;
        }

        public string GetMessage()
        {
            return "Hello from PracticeRepository!";
        }

        public async Task<PracticeResultDto> PracticeTasksAsync()
        {

            //Task
            //A Task is not a worker. It is a job description.
            //A task is like telling the system: “Please run this job whenever you decide is best.”
            //The Task uses the thread pool(a shared group of workers).
            //When you run a Task, .NET finds a free worker from the thread pool.
            //Tasks are lighter and automatically managed.
            //Perfect for asynchronous code.

            //What happens:
            //Task starts → .NET uses a thread from the thread pool.
            //If your code is async waiting (like await Task.Delay) →
            //the thread is released and free to work on something else.
            //When the wait finishes, another thread continues the work.

            //Pros
            //• Very lightweight.
            //• Automatically uses thread pool(no extra threads unless needed).
            //• Works best with async / await.
            //• Easier to write safe code.
            //• 

            //Cons
            //• Less low - level control than threads.
            //• Not for scenarios where you must force a dedicated thread.
            var stopwatch = Stopwatch.StartNew();

            var brandCount = await petStoreDbContext.Brands.CountAsync().con;

            //async means:
            //This method can pause without blocking a thread.

            //await means:
            //Pause here until this task finishes, and meanwhile free the thread.

            //.Result blocks the thread.

            //Task.Wait() is basically the same as .Result but without returning a value.

            //ConfigureAwait(false) Means:

            //Pause here
            //Free the thread
            //Continue later
            //But you don’t care which thread continues the method

            //With false
            //Continue on any thread.
            //Faster.
            //Avoids deadlocks in libraries and background code.


            //await = non - blocking wait
            //.Result / .Wait = blocking wait
            //ConfigureAwait(false) = don’t return to UI thread; finish anywhere
            if (brandCount == 0)
            {
                stopwatch.Stop();
                return new PracticeResultDto { Brand = null, Foods = new List<FoodDto>(), ElapsedMilliseconds = stopwatch.ElapsedMilliseconds };
            }

            var random = new Random();
            var index = random.Next(0, brandCount);

            var brand = await petStoreDbContext.Brands.Skip(index).FirstOrDefaultAsync();
            if (brand == null)
            {
                stopwatch.Stop();
                return new PracticeResultDto { Brand = null, Foods = new List<FoodDto>(), ElapsedMilliseconds = stopwatch.ElapsedMilliseconds };
            }

            var foods = await petStoreDbContext.Food.Where(f => f.BrandId == brand.Id).ToListAsync();

            var mappedBrand = mapper.Map<BrandDto>(brand);
            var mappedFoods = mapper.Map<IEnumerable<FoodDto>>(foods);

            stopwatch.Stop();

            return new PracticeResultDto
            {
                Brand = mappedBrand,
                Foods = mappedFoods,
                ElapsedMilliseconds = stopwatch.ElapsedMilliseconds
            };
        }

        public PracticeResultDto PracticeThreads()
        {
            //Thread
            //A thread is like a worker.When you create a thread, you hire a new worker to do a job.
            //It works independently and runs code in parallel with your main program.
            //When a thread is doing work, it is busy the whole time.

            //Pros
            //• Full control(start, stop, sleep, priority).
            //• Good for very low-level or special scenarios.

            //Cons
            //• Heavy: uses more memory.
            //• You must manage it yourself.
            //• Easy to make mistakes(deadlocks, race conditions).
            //• Creating many threads slows the app.

            var stopwatch = Stopwatch.StartNew();
            PracticeResultDto result = null;

            var thread = new Thread(() =>
            {
                try
                {
                    var brandCount = petStoreDbContext.Brands.Count();
                    if (brandCount == 0)
                    {
                        result = new PracticeResultDto { Brand = null, Foods = new List<FoodDto>(), ElapsedMilliseconds = 0 };
                        return;
                    }

                    var random = new Random();
                    var index = random.Next(0, brandCount);

                    var brand = petStoreDbContext.Brands.Skip(index).FirstOrDefault();
                    if (brand == null)
                    {
                        result = new PracticeResultDto { Brand = null, Foods = new List<FoodDto>(), ElapsedMilliseconds = 0 };
                        return;
                    }

                    var foods = petStoreDbContext.Food.Where(f => f.BrandId == brand.Id).ToList();

                    var mappedBrand = mapper.Map<BrandDto>(brand);
                    var mappedFoods = mapper.Map<IEnumerable<FoodDto>>(foods);

                    result = new PracticeResultDto
                    {
                        Brand = mappedBrand,
                        Foods = mappedFoods,
                        ElapsedMilliseconds = 0
                    };
                }
                catch
                {
                    result = new PracticeResultDto { Brand = null, Foods = new List<FoodDto>(), ElapsedMilliseconds = 0 };
                }
            });

            // Tell the worker (thread) to start. This does not block — the worker runs at the same time.
            thread.Start();

            // Wait for the worker to finish. This blocks the current thread until the worker exits.
            // Use Join() when you need the result before continuing, but avoid it in web request threads
            // because it blocks resources and reduces scalability.
            thread.Join();

            stopwatch.Stop();

            if (result == null)
                result = new PracticeResultDto { Brand = null, Foods = new List<FoodDto>(), ElapsedMilliseconds = stopwatch.ElapsedMilliseconds };
            else
                result.ElapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            return result;
        }

        // Concurrency Example Methods
        // These two methods demonstrate concurrency when called together with Task.WhenAll

        public async Task<IEnumerable<FoodDto>> GetAllFoodsAsync()
        {
            var foods = await petStoreDbContext.Food.ToListAsync();
            return mapper.Map<IEnumerable<FoodDto>>(foods);
        }

        public async Task<IEnumerable<ToyDto>> GetAllToysAsync()
        {
            var toys = await petStoreDbContext.Toys.ToListAsync();
            return mapper.Map<IEnumerable<ToyDto>>(toys);
        }

        public async Task PracticeAsyncVoidAsync()
        {
            // async void is DANGEROUS and should almost NEVER be used.
            // This method demonstrates why with comments.

            // ❌ WRONG - do NOT do this (example of what NOT to do):
            // async void BadMethod()
            // {
            //     await Task.Delay(1000);
            //     // If an exception happens here, it will CRASH the app because there's no way to catch it.
            //     throw new Exception("Error!");
            // }

            // ✅ CORRECT - always use async Task instead:
            // async Task GoodMethod()
            // {
            //     await Task.Delay(1000);
            //     // Exceptions can be caught by the caller.
            //     throw new Exception("Error!");
            // }

            // This method uses async Task (correct).
            // It simulates an operation that you cannot "await" from the controller.
            // (In real life, only use async void for event handlers like button clicks).

            await Task.Delay(500);

            var allFoods = await petStoreDbContext.Food.ToListAsync();
            var foodCount = allFoods.Count;

            // No return value, but exception handling is possible because it's async Task.
        }
    }
}
