using Microsoft.AspNetCore.Mvc;
using System;
using globeChekServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using System.Web.Http.Cors;
using globeChekModels;

namespace GlobeChek_config.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    
    public class HomeController : Controller
    {
        private IGetDetails _IGetDetails;
        private IGetClientDetails _GetClientDetails;
        public HomeController(IGetDetails getDetails, IGetClientDetails getClientDetails)
        {
            _IGetDetails = getDetails;
            _GetClientDetails = getClientDetails;
        }
        [HttpGet("getGlobeDetails")]
        public IActionResult getDetails([FromQuery] string ClientName)
        {

                var res = _IGetDetails.getConfigDetailsAsync(ClientName);
                return Ok(res);
            
        }
        [HttpGet("getClientName")]
        public IActionResult getClient()
        {
            List<ClientModel> res = _GetClientDetails.GetClient();
            return Ok(res) ;
            
        }
    }
}
