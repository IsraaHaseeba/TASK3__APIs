using Microsoft.AspNetCore.Identity;

namespace UsersAPI.Auth
{
   
        public  class UserRole: IdentityRole<int>
        {
            public const string Admin = "Admin";
            public const string User = "User";
        }
    
}
