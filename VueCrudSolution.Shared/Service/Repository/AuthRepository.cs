using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VueCrudSolution.Data.Constants;
using VueCrudSolution.Data.Models;
using VueCrudSolution.Data.Models.Extensions;
using VueCrudSolution.Shared.DataAccess.Repository;
using VueCrudSolution.Shared.Service.Interfaces;

namespace VueCrudSolution.Shared.Service.Repository
{
    public class AuthRepository : IAuthRepository
    {

        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly RoleManager<ApplicationIdentityRole> _roleManager;

        public AuthRepository(
            UserManager<ApplicationIdentityUser> userManager,
            RoleManager<ApplicationIdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task AssignRolePermissionToUser(string roleName, ApplicationIdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var userClaims = await _userManager.GetClaimsAsync(user);
            if (userClaims.Any())
                await _userManager.RemoveClaimsAsync(user, userClaims);

            var iposbiPermissions = ((Permission[])Enum.GetValues(typeof(Permission))).Where(p => p.GetPermissionCategory() == roleName);

            if (roleName == RoleHelpers.ADMIN)
            {
                var adminPermissions = ((Permission[])Enum.GetValues(typeof(Permission)))
                    .Select(item => new Claim(item.ToString(), ((int)item).ToString()));

                var otherPermission = new List<Claim>
                {
                   new Claim(Permission.PU_04.ToString(), ((int) Permission.PU_04).ToString()),
                    new Claim(Permission.PU_05.ToString(), ((int) Permission.PU_05).ToString()),
                    new Claim(Permission.PU_06.ToString(), ((int) Permission.PU_06).ToString()),
                };

                var permissions = adminPermissions.Cast<Claim>().Concat(otherPermission.Cast<Claim>());
                await _userManager.AddClaimsAsync(user, permissions);
                return;
            }

            var pList = iposbiPermissions.Select(item => new Claim(item.ToString(), ((int)item).ToString()));
            await _userManager.AddClaimsAsync(user, pList);
        }

        public async Task AssignPermissionsToUser(List<Permission> permissions, Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                return;

            var userClaims = await _userManager.GetClaimsAsync(user);
            if (userClaims.Any())
                await _userManager.RemoveClaimsAsync(user, userClaims);

            var userNewClaims = permissions.Select(p => new Claim(p.ToString(), ((int)p).ToString()));
            _userManager.AddClaimsAsync(user, userNewClaims).Wait();
        }

        public async Task<ApplicationIdentityRole> GetRole(Guid id)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            return role;
        }

        public async Task<IEnumerable<ApplicationIdentityRole>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }
    }
}
