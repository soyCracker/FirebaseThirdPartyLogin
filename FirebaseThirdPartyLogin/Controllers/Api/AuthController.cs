using System;
using System.Diagnostics;
using FirebaseThirdPartyLogin.Models.AuthModel;
using Microsoft.AspNetCore.Mvc;

namespace FirebaseThirdPartyLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IActionResult index(AuthVO vo)
        {
            Debug.WriteLine("AuthController Uid:" + vo.Uid);
            return Ok(new { Value = true, ErrorCode = 0});
        }
    }
}