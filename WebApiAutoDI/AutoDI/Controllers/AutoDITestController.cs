using AutoDI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoDITestController : ControllerBase
    {
        private readonly IAutoDIService _autoDIService;
        public AutoDITestController(IAutoDIService autoDIService)
        {
            _autoDIService = autoDIService;
        }

        [HttpGet]
        public int Get123() 
        {
            return _autoDIService.Return123();
        }
    }
}
