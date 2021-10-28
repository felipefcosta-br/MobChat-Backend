using Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobChat.Microservices.IamMicroservice.Admin.Api.Dtos.Users
{
    public class AppUserPasswordDto<TKey>
    {
        public TKey AppUserId { get; set; }

        public UserDto<TKey> user { get; set; }
        public UserChangePasswordApiDto<TKey> password { get; set; }
    }
}
