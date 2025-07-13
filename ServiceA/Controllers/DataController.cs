using Microsoft.AspNetCore.Mvc;

namespace ServiceA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;

        public DataController(ILogger<DataController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var headers = HttpContext.Request.Headers
                   .ToDictionary(h => h.Key, h => h.Value.ToString());

            return Ok(headers);

            //return Enumerable.Range(1, 5).Select(index => new
            //{
            //    Service = "ServiceA",
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    Value = index.ToString()
            //})
            //.ToArray();
        }
    }
}
