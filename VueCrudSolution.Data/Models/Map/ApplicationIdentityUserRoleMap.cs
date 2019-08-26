using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VueCrudSolution.Data.Models.Extensions;

namespace VueCrudSolution.Data.Models.Map
{
    public class ApplicationIdentityUserRoleMap : IEntityTypeConfiguration<ApplicationIdentityUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationIdentityUserRole> builder)
        {
            builder.HasKey(p => new { p.UserId, p.RoleId });

            var users_roles = new[]
            {
                new
                {
                    UserId = DefaultUserKeys.SysUserId,
                    RoleId = RoleHelpers.SYS_ADMIN_ID(),
                 },
                new
                {
                    UserId = DefaultUserKeys.SuperAdminUserId,
                    RoleId = RoleHelpers.SUPER_ADMIN_ID(),
                 },
                 new
                {
                    UserId = DefaultUserKeys.AdminUserId,
                    RoleId = RoleHelpers.ADMIN_ID(),
                },
                 new
                {
                    UserId = DefaultUserKeys.PowerUserId,
                    RoleId = RoleHelpers.POWER_USER_ID()
                },
                 new
                {
                    UserId = DefaultUserKeys.ManagerUserId,
                    RoleId = RoleHelpers.MANAGER_ID(),
                },
                  new
                {
                    UserId = DefaultUserKeys.UsersUserId,
                    RoleId = RoleHelpers.USERS_ID(),
                }
            };

            //builder.HasKey(model => new { model.UserId, model.RoleId });
            builder.HasData(users_roles);
        }
    }
}
