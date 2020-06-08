using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PlexWebHook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlexHook : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var result = new ActionResult<string>("ok12");

            var body = string.Empty;
            
            using (var reader = new StreamReader(Request.Body))
            {
                body = await reader.ReadToEndAsync();
            }

            return result;
        }
    }
}