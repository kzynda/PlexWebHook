using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace PlexWebHook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlexHookController : ControllerBase
    {
        private readonly ILogger<PlexHookController> _logger;
        
        public PlexHookController(ILogger<PlexHookController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(IFormCollection d)
        {
            var result = new ActionResult<string>("ok12");

            var payload = d["payload"];

            D dd = JsonConvert.DeserializeObject<D>(payload);

            string eventName = dd.Event;
        
            _logger.LogInformation("dd", dd);
            
            return result;
        }
        
        public class D
        {   
            public string Event { get; set; }
        }
    }
}