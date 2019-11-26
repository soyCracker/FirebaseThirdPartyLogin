using System.Linq;
using FirebaseAuthEntity.Entities;
using FirebaseThirdPartyLogin.BusinessLogic.JWT;
using FirebaseThirdPartyLogin.Models.AuthModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirebaseThirdPartyLogin.Controllers.Api
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly FirebaseAuthDBContext context;
        private readonly ILogger log;    

        public AuthController(FirebaseAuthDBContext context, ILogger<AuthController> log)
        {
            this.context = context;
            this.log = log;
            log.LogDebug("AuthController");
        }

        [HttpPost]
        public IActionResult Index([FromBody]AuthVO vo)
        {
            log.LogDebug("AuthController Uid:" + vo.Uid);
            log.LogDebug("AuthController DisplayName:" + vo.DisplayName);
            log.LogDebug("AuthController Email:" + vo.Email);
            log.LogDebug("AuthController EmailVerified:" + vo.EmailVerified);
            log.LogDebug("AuthController PhotoURL:" + vo.PhotoURL);
            log.LogDebug("AuthController IsAnonymous:" + vo.IsAnonymous);

            UpdateUserInDB(vo);
            Response.Cookies.Append("AccessToken", GetToken(vo.Uid, vo.DisplayName));
            return Ok(new { Value = true, ErrorCode = 0 });
        }

        private void UpdateUserInDB(AuthVO vo)
        {
            AuthUser existUser = context.AuthUser.SingleOrDefault(x => x.Id == vo.Uid);
            if (existUser == null)
            {
                AuthUser newUser = new AuthUser();
                newUser.Id = vo.Uid;
                newUser.DisplayName = vo.DisplayName;
                newUser.Email = vo.Email;
                newUser.EmailVerified = vo.EmailVerified;
                newUser.IsAnonymous = vo.IsAnonymous;
                newUser.PhotoUrl = vo.PhotoURL;
                context.AuthUser.Add(newUser);
                context.SaveChanges();
            }
            else
            {
                existUser.DisplayName = vo.DisplayName;
                existUser.Email = vo.Email;
                existUser.EmailVerified = vo.EmailVerified;
                existUser.IsAnonymous = vo.IsAnonymous;
                existUser.PhotoUrl = vo.PhotoURL;
                context.SaveChanges();
            }
        }

        private string GetToken(string uid, string username)
        {
            string issuser = "JwtAuthDemo";
            int expires = 30;//minute
            return JwtService.GenerateToken(issuser, uid, username, expires);
        }
    }
}
