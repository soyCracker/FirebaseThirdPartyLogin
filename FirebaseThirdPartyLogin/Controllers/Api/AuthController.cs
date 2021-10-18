using FirebaseAuth.Service.Services;
using FirebaseAuthEntity.Entities;
using FirebaseThirdPartyLogin.Models.AuthModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirebaseThirdPartyLogin.Controllers.Api
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private AuthUserService authUserService;
        private readonly ILogger log;    

        public AuthController(ILogger<AuthController> log)
        {
            this.log = log;
            log.LogDebug("AuthController");
            authUserService = new AuthUserService();
        }

        [HttpPost]
        public IActionResult Index([FromBody]AuthVO vo)
        {
            log.LogDebug("AuthController AccessToken:" + vo.AccessToken);
            log.LogDebug("AuthController Uid:" + vo.Uid);
            log.LogDebug("AuthController DisplayName:" + vo.DisplayName);
            log.LogDebug("AuthController Email:" + vo.Email);
            log.LogDebug("AuthController EmailVerified:" + vo.EmailVerified);
            log.LogDebug("AuthController PhotoURL:" + vo.PhotoURL);
            log.LogDebug("AuthController IsAnonymous:" + vo.IsAnonymous);

            UpdateUser(vo);
            return Ok(new { Value = true, ErrorCode = 0 });
        }

        private void UpdateUser(AuthVO vo)
        {
            AuthUser newUser = new AuthUser();
            newUser.Id = vo.Uid;
            newUser.DisplayName = vo.DisplayName;
            newUser.Email = vo.Email;
            newUser.EmailVerified = vo.EmailVerified;
            newUser.IsAnonymous = vo.IsAnonymous;
            newUser.PhotoUrl = vo.PhotoURL;
            authUserService.UpdateUser(newUser);
        }

        [HttpPost]
        [Authorize]
        [Route("Test")]
        public IActionResult Test()
        {
            log.LogDebug("Good Auth");

            return Ok(new { Value = true, ErrorCode = 0 });
        }
    }
}
