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
        public IEnumerable<object> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new
            {
                Service = "ServiceA",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Value = index.ToString()
            })
            .ToArray();
        }
    }
}
