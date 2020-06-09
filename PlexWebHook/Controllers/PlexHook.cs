using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PlexWebHook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlexHook : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Post(IFormCollection d)
        {
            var result = new ActionResult<string>("ok12");

            var payload = d["payload"];

            D dd = JsonConvert.DeserializeObject<D>(payload);

            return result;
        }
        
        public class D
        {   
            public string Event { get; set; }
        }
    }
}