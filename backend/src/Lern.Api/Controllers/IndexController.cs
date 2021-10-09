using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public OkObjectResult Get()
        {
            return Ok(new Dictionary<string, string>
            {
                {
                    "version", "1"
                }
            });
        }
    }
}