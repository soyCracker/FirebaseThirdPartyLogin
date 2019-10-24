using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirebaseThirdPartyLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : Controller
    {
        [HttpGet("public")]
        public string Public()
        {
            return "This endpoint is public.";
        }

        [Authorize]
        [HttpGet("protected")]
        public string Protected()
        {
            return "This endpoint is protected.";
        }
    }
}