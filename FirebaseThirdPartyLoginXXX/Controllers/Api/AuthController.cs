using System;
using System.Diagnostics;
using FirebaseAuthEntity.Entities;
using FirebaseThirdPartyLogin.Models.AuthModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace FirebaseThirdPartyLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly FirebaseAuthDBContext context;
        private readonly ILogger log;

        public AuthController(FirebaseAuthDBContext context, ILogger<AuthController> log)
        {
            this.context = context;
            this.log = log;
            log.LogDebug("AuthController");
        }

        [Route("test")]
        [HttpPost]
        public IActionResult Test(/*AuthVO vo*/)
        {
            //log.LogDebug("@@@@@@@@@@@@@@@@@@@@@@@ AuthController Uid:" + vo.Uid);
            /*AuthUser existUser = context.AuthUser.SingleOrDefault(x => x.Id == vo.Uid);
            log.LogDebug("@@@@@@@@@@@@@@@@@@@@@@@@ AuthController 1");
            if (existUser == null)
            {
                log.LogDebug("AuthController 2");
                AuthUser newUser = new AuthUser();
                newUser.Id = vo.Uid;
                newUser.DisplayName = vo.DisplayName;
                newUser.Email = vo.Email;
                newUser.EmailVerified = vo.EmailVerified;
                newUser.IsAnonymous = vo.IsAnonymous;
                newUser.PhotoUrl = vo.PhotoURL;
                newUser.ProviderData = vo.ProviderData;
                context.AuthUser.Add(newUser);
                context.SaveChanges();
            }
            else
            {
                log.LogDebug("AuthController 3");
                existUser.DisplayName = vo.DisplayName;
                existUser.Email = vo.Email;
                existUser.EmailVerified = vo.EmailVerified;
                existUser.IsAnonymous = vo.IsAnonymous;
                existUser.PhotoUrl = vo.PhotoURL;
                existUser.ProviderData = vo.ProviderData;
                context.SaveChanges();
            }
            log.LogDebug("AuthController 4");*/
            return Ok(new { Value = true, ErrorCode = 0 });
        }
    }
}