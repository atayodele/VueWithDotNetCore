using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VueCrudSolution.Data.Constants;
using VueCrudSolution.Data.Models.Extensions;

namespace VueCrudSolution.Data.Models.Map
{
    public class ApplicationIdentityUserClaimMap : IEntityTypeConfiguration<ApplicationIdentityUserClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationIdentityUserClaim> builder)
        {
            builder.HasKey(c => c.Id);
            //builder.Property(c => c.Id).ValueGeneratedNever();
            //builder.Property(c => c.Id).UseSqlServerIdentityColumn();
            var iposbiPermissions = (Permission[])Enum.GetValues(typeof(Permission));

            int count = 1;
            foreach (var item in iposbiPermissions)
            {
                switch (item.GetPermissionCategory())
                {
                    case (RoleHelpers.ADMIN):
                        {
                            builder.HasData(new ApplicationIdentityUserClaim()
                            {
                                Id = count++,
                                UserId = DefaultUserKeys.AdminUserId,
                                ClaimType = item.ToString(),
                                ClaimValue = ((int)item).ToString()
                            });
                            break;
                        }

                    case (RoleHelpers.POWER_USER):
                        {
                            builder.HasData(new ApplicationIdentityUserClaim()
                            {
                                Id = count++,
                                UserId = DefaultUserKeys.PowerUserId,
                                ClaimType = item.ToString(),
                                ClaimValue = ((int)item).ToString()
                            });
                            break; 
                        }
                    case (RoleHelpers.MANAGER):
                        {
                            builder.HasData(new ApplicationIdentityUserClaim()
                            {
                                Id = count++,
                                UserId = DefaultUserKeys.ManagerUserId,
                                ClaimType = item.ToString(),
                                ClaimValue = ((int)item).ToString()
                            });
                            break; 
                        }
                    case (RoleHelpers.SUPER_ADMIN):
                        {
                            builder.HasData(new ApplicationIdentityUserClaim()
                            {
                                Id = count++,
                                UserId = DefaultUserKeys.SuperAdminUserId,
                                ClaimType = item.ToString(),
                                ClaimValue = ((int)item).ToString()
                            });
                            break; 
                        }
                    default:
                        break;
                }
            }
        }
    }
}
