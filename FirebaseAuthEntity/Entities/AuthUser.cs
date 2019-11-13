using System;
using System.Collections.Generic;

namespace FirebaseAuthEntity.Entities
{
    public partial class AuthUser
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public bool? EmailVerified { get; set; }
        public string PhotoUrl { get; set; }
        public bool? IsAnonymous { get; set; }
        public string ProviderData { get; set; }
    }
}
