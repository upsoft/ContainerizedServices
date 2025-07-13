using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ServiceA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoadController : ControllerBase
    {
        private readonly ILogger<LoadController> _logger;
        private readonly Random rnd;

        public LoadController(ILogger<LoadController> logger)
        {
            _logger = logger;
            rnd = new Random();
        }

        [HttpGet("mem")]
        public async Task<IActionResult> Memory()
        {
            var time = rnd.Next(50, 500);
            // Allocate a large amount of memory (e.g., 500 MB)
            byte[] buffer = new byte[500 * 1024 * 1024];
            Thread.Sleep(time);
            return Ok($"Allocate a large amount of memory for {time} seconds");
        }

        [HttpGet("cpu")]
        public async Task<IActionResult> Cpu()
        {
            // Spin CPU for 10 seconds
            var sw = Stopwatch.StartNew();
            var time = rnd.Next(1, 10);

            while (sw.Elapsed < TimeSpan.FromSeconds(time))
            {
                Math.Sqrt(new Random().NextDouble()); // some meaningless work
            }
            return Ok($"Burned CPU for {time} seconds");
        }
    }
}
