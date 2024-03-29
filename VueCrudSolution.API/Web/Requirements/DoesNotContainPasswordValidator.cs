﻿using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace VueCrudSolution.API.Web.Requirements
{
    public class DoesNotContainPasswordValidator<TUser> : IPasswordValidator<TUser> where TUser : class
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
        {
            //var username = await manager.GetUserNameAsync(user);
            var email = await manager.GetEmailAsync(user);

            if (email == password)
                return IdentityResult.Failed(new IdentityError { Description = "Password cannot contain username" });
            if (password.Contains("password"))
                return IdentityResult.Failed(new IdentityError { Description = "Password cannot conain password" });

            return IdentityResult.Success;
        }
    }
}
