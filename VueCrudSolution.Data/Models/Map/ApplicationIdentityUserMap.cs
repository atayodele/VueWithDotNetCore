using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VueCrudSolution.Data.Models.Extensions;

namespace VueCrudSolution.Data.Models.Map
{
    public class ApplicationIdentityUserMap : IEntityTypeConfiguration<ApplicationIdentityUser>
    {
        public ApplicationIdentityUserMap()
        {
        }

        public PasswordHasher<ApplicationIdentityUser> Hasher { get; set; }
        = new PasswordHasher<ApplicationIdentityUser>();
        public void Configure(EntityTypeBuilder<ApplicationIdentityUser> builder)
        {
            SetupSuperAdmin(builder);
            SetupAdmin(builder);
            SetupPowerUser(builder);
            SetupManager(builder);
        }


        private void SetupSuperAdmin(EntityTypeBuilder<ApplicationIdentityUser> builder)
        {
            var sysUser = new ApplicationIdentityUser
            {
                Activated = false,
                CreatedOnUtc = DateTime.Now,
                FullName = "Meyo Solutions",
                FirstName = "Meyo",
                LastName = "Solutions",
                Id = DefaultUserKeys.SysUserId,
                LastLoginDate = DateTime.Now,
                Email = DefaultUserKeys.SysUserEmail,
                EmailConfirmed = false,
                NormalizedEmail = DefaultUserKeys.SysUserEmail.ToUpper(),
                PhoneNumber = DefaultUserKeys.SysMobile,
                UserName = DefaultUserKeys.SysUserEmail,
                NormalizedUserName = DefaultUserKeys.SysUserEmail.ToUpper(),
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = false,
                PasswordHash = Hasher.HashPassword(null, "pa55w0rd"),
                SecurityStamp = "99ae0c45-d682-4542-9ba7-1281e471916b"
            };

            var superUser = new ApplicationIdentityUser
            {
                Activated = true,
                CreatedOnUtc = DateTime.Now,
                Id = DefaultUserKeys.SuperAdminUserId,
                FullName = "Meyo Solutions",
                FirstName = "Meyo",
                LastName = "Solutions",
                LastLoginDate = DateTime.Now,
                Email = DefaultUserKeys.SuperAdminUserEmail,
                EmailConfirmed = true,
                NormalizedEmail = DefaultUserKeys.SuperAdminUserEmail.ToUpper(),
                PhoneNumber = DefaultUserKeys.SuperAdminMobile,
                UserName = DefaultUserKeys.SuperAdminUserEmail,
                NormalizedUserName = DefaultUserKeys.SuperAdminUserEmail.ToUpper(),
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = true,
                PasswordHash = Hasher.HashPassword(null, "pa55w0rd"),
                SecurityStamp = "016020e3-5c50-40b4-9e66-bba56c9f5bf2"
            };

            builder.HasData(sysUser, superUser);
        }

        private void SetupAdmin(EntityTypeBuilder<ApplicationIdentityUser> builder)
        {
            var adminUser = new ApplicationIdentityUser
            {
                Activated = true,
                CreatedOnUtc = DateTime.Now,
                FullName = "Ayeni Ayodele",
                FirstName = "Ayeni",
                LastName = "Ayodele",
                Id = DefaultUserKeys.AdminUserId,
                LastLoginDate = DateTime.Now,
                Email = DefaultUserKeys.AdminUserEmail,
                EmailConfirmed = true,
                NormalizedEmail = DefaultUserKeys.AdminUserEmail.ToUpper(),
                PhoneNumber = DefaultUserKeys.AdminMobile,
                UserName = DefaultUserKeys.AdminUserEmail,
                NormalizedUserName = DefaultUserKeys.AdminUserEmail.ToUpper(),
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = true,
                PasswordHash = Hasher.HashPassword(null, "pa55w0rd"),
                SecurityStamp = "953d3fd1-99e3-4fe7-a20d-3598baa96099"
            };

            builder.HasData(adminUser);
        }

        private void SetupPowerUser(EntityTypeBuilder<ApplicationIdentityUser> builder)
        {
            var powerUser = new ApplicationIdentityUser
            {
                Activated = true,
                CreatedOnUtc = DateTime.Now,
                FullName = "Ayeni Ayodele",
                FirstName = "Ayeni",
                LastName = "Ayodele",
                Id = DefaultUserKeys.PowerUserId,
                LastLoginDate = DateTime.Now,
                Email = DefaultUserKeys.PowerUserEmail,
                EmailConfirmed = true,
                NormalizedEmail = DefaultUserKeys.PowerUserEmail.ToUpper(),
                PhoneNumber = DefaultUserKeys.PowerUserMobile,
                UserName = DefaultUserKeys.PowerUserEmail,
                NormalizedUserName = DefaultUserKeys.PowerUserEmail.ToUpper(),
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = true,
                PasswordHash = Hasher.HashPassword(null, "pa55w0rd"),
                SecurityStamp = "9c41c8cc-b489-40c6-bbcf-12edee681919"
            };

            builder.HasData(powerUser);
        }

        private void SetupManager(EntityTypeBuilder<ApplicationIdentityUser> builder)
        {
            var manager = new ApplicationIdentityUser
            {
                Activated = true,
                CreatedOnUtc = DateTime.Now,
                FullName = "Ayeni Ayodele",
                FirstName = "Ayeni",
                LastName = "Ayodele",
                Id = DefaultUserKeys.ManagerUserId,
                LastLoginDate = DateTime.Now,
                Email = DefaultUserKeys.ManagerEmail,
                EmailConfirmed = true,
                NormalizedEmail = DefaultUserKeys.ManagerEmail.ToUpper(),
                PhoneNumber = DefaultUserKeys.ManagerMobile,
                UserName = DefaultUserKeys.ManagerEmail,
                NormalizedUserName = DefaultUserKeys.ManagerEmail.ToUpper(),
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = true,
                PasswordHash = Hasher.HashPassword(null, "pa55w0rd"),
                SecurityStamp = "bd5db7e5-b870-48cf-839b-5862d0b86614"
            };

            builder.HasData(manager);
        }
    }
}
