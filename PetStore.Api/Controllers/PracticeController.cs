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
    }
}
