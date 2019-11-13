using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirebaseThirdPartyLogin.Models.AuthModel
{
    public class AuthVO
    {
        public string Uid { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string PhotoURL { get; set; }
        public bool IsAnonymous { get; set; }
        public string ProviderData { get; set; }
    }
}
