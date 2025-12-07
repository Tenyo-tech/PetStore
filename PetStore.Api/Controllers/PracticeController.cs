using Microsoft.AspNetCore.Mvc;
using PetStore.Business.Services;

namespace PetStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PracticeController : ControllerBase
    {
        private readonly IPracticeService practiceService;

        public PracticeController(IPracticeService practiceService)
        {
            this.practiceService = practiceService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var message = practiceService.GetMessage();
            return Ok(new { message });
        }

        [HttpGet("PracticeTasks")]
        public async Task<IActionResult> PracticeTasks()
        {
            var result = await practiceService.PracticeTasksAsync();
            return Ok(result);
        }

        [HttpGet("PracticeThreads")]
        public IActionResult PracticeThreads()
        {
            var result = practiceService.PracticeThreads();
            return Ok(result);
        }

        [HttpGet("PracticeConcurrency")]
        public async Task<IActionResult> PracticeConcurrency()
        {
            var result = await practiceService.PracticeConcurrencyAsync();
            return Ok(result);
        }

        [HttpGet("PracticeAsyncVoid")]
        public async Task<IActionResult> PracticeAsyncVoid()
        {
            // This endpoint demonstrates why async void is dangerous.
            // We use async Task here (the correct way) instead of async void.
            // 
            // If the underlying operation throws an exception, we CAN catch it.
            // If we used async void, the exception would crash the entire application!

            try
            {
                await practiceService.PracticeAsyncVoidAsync();
                return Ok(new { message = "Operation completed successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }



    }
}
