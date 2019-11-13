﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirebaseAuthEntity.Entities;
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
            //log.LogDebug("AuthController ProviderData:" + vo.ProviderData);
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
                //newUser.ProviderData = vo.ProviderData;
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
                //existUser.ProviderData = vo.ProviderData;
                context.SaveChanges();
            }
            return Ok(new { Value = true, ErrorCode = 0 });
        }
    }
}
