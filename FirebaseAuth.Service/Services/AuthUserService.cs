using FirebaseAuthEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseAuth.Service.Services
{
    public class AuthUserService
    {
        //private readonly FirebaseAuthDBContext context;

        public void UpdateUser(AuthUser user)
        {
            using(FirebaseAuthDBContext context = new FirebaseAuthDBContext { })
            {
                AuthUser existUser = context.AuthUser.SingleOrDefault(x => x.Id == user.Id);
                if (existUser == null)
                {
                    context.AuthUser.Add(user);
                    context.SaveChanges();
                }
                else
                {
                    existUser.DisplayName = user.DisplayName;
                    existUser.Email = user.Email;
                    existUser.EmailVerified = user.EmailVerified;
                    existUser.IsAnonymous = user.IsAnonymous;
                    existUser.PhotoUrl = user.PhotoUrl;
                    context.SaveChanges();
                }
            }
            
        }
    }
}
