using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using VueCrudSolution.API.Web.Requirements;
using VueCrudSolution.Data.Models;

namespace VueCrudSolution.API.Web.Policies.Handlers
{
    public class PermissionAuthorizationHandler
        : AuthorizationHandler<PermissionsAuthorizationRequirement>
    {
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationIdentityUser> _userManager;

        public PermissionAuthorizationHandler(ILogger<PermissionAuthorizationHandler> logger,
                                              UserManager<ApplicationIdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                             PermissionsAuthorizationRequirement requirement)
        {
            var user = await _userManager.GetUserAsync(context.User);
            var currentUserPermissions = (await _userManager.GetClaimsAsync(user)).ToList();


            List<int> permissionValues = new List<int>();
            currentUserPermissions.ForEach(c =>
            {
                if (!int.TryParse(c.Value, out int result))
                    return;

                permissionValues.Add(result);
            });

            var authorized = requirement.RequiredPermissions.AsParallel()
                .All(rp => permissionValues.Contains((int)rp));

            if (authorized)
                context.Succeed(requirement);
        }
    }
}
