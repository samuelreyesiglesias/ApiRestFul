using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("Api/Simplest")]
    public class SimplestController : Controller
    {
        [Produces("text/plain")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var StringContent = "Hello World  , 2nd example, easy example";
                return Ok(StringContent);
            }
            catch (Exception Ex)
            {
                return Ok(BadRequest().ToString());
            }
        }
    }
}
