using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VueCrudSolution.Data.Models.Extensions;

namespace VueCrudSolution.Data.Models.Map
{
    public class ApplicationIdentityRoleMap : IEntityTypeConfiguration<ApplicationIdentityRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationIdentityRole> builder)
        {
            var roles = new ApplicationIdentityRole[]
            {
                new ApplicationIdentityRole
                {
                    Id = RoleHelpers.SYS_ADMIN_ID(),
                    Name =RoleHelpers.SYS_ADMIN,
                    NormalizedName = RoleHelpers.SYS_ADMIN
                },

                new ApplicationIdentityRole
                {
                    Id = RoleHelpers.SUPER_ADMIN_ID(),
                    Name =RoleHelpers.SUPER_ADMIN,
                    NormalizedName = RoleHelpers.SUPER_ADMIN
                },
               new  ApplicationIdentityRole
               {
                   Id = RoleHelpers.ADMIN_ID(),
                    Name=  RoleHelpers.ADMIN,
                    NormalizedName = RoleHelpers.ADMIN

                },
                new  ApplicationIdentityRole
               {
                    Id = RoleHelpers.POWER_USER_ID(),
                    Name=  RoleHelpers.POWER_USER,
                    NormalizedName = RoleHelpers.POWER_USER
                },
               new  ApplicationIdentityRole
               {
                    Id =  RoleHelpers.MANAGER_ID(),
                    Name=  RoleHelpers.MANAGER,
                    NormalizedName = RoleHelpers.MANAGER
                },
               new  ApplicationIdentityRole
               {
                    Id =  RoleHelpers.USERS_ID(),
                    Name=  RoleHelpers.USERS,
                    NormalizedName = RoleHelpers.USERS
                }
            };

            builder.HasData(roles);
        }
    }
}
