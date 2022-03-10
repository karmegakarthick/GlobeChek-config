using Microsoft.AspNetCore.Mvc;
using System;
using globeChekServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobeChek_config.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        public IGetDetails _IGetDetails;
        public HomeController(IGetDetails getDetails)
        {
            _IGetDetails = getDetails;
        }
        [HttpGet("getGlobeDetails")]
        public IActionResult getDetails([FromQuery] String client)
        {
                var res = _IGetDetails.getConfigDetailsAsync(client);
                return Ok(res);
        }
    }
}
