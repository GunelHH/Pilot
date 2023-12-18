using System;
using Microsoft.AspNetCore.Mvc;

namespace Pilot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V1 : ControllerBase
    {
        public IActionResult Buildings()
        {
            return Ok();
        }
    }
}

