using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontendService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly HttpClient _httpClient;

        public DataController(ILogger<DataController> logger, HttpClient httpClient)
        {
            _httpClient = httpClient;       
            _logger = logger;
        }

        [HttpGet("getfrontend")]
        public IEnumerable<object> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new 
            {
                Service = "FrontendService",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Value = index.ToString()
            })
            .ToArray();
        }

        [HttpGet("getbackend")]
        public async Task<IActionResult> GetBackend()
        {
            string url = Environment.GetEnvironmentVariable("backendservice");
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json"); // or return Ok(JsonDocument.Parse(content));
        }
    }
}
