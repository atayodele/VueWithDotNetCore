using System;

namespace VueCrudSolution.Data.Models.Extensions
{
    public static class DefaultUserKeys
    {
        public const string SysUserEmail = "system@gmail.com";
        public static readonly Guid SysUserId = Guid.Parse("1989883f-4f99-43bf-a754-239bbbfec00e");
        public const string SysMobile = "07032369246";

        public const string SuperAdminUserEmail = "superadmin@gmail.com";
        public static readonly Guid SuperAdminUserId = Guid.Parse("3fb897c8-c25d-4328-9813-cb1544369fba");
        public const string SuperAdminMobile = "07032369246";

        public static readonly Guid AdminUserId = Guid.Parse("129712e3-9214-4dd3-9c03-cfc4eb9ba979");
        public const string AdminMobile = "07032369246";
        public const string AdminUserEmail = "admin@gmail.com";

        public static readonly Guid PowerUserId = Guid.Parse("193a9488-ad75-41d6-a3e0-db3f10b6468f");
        public const string PowerUserMobile = "07032369246";
        public const string PowerUserEmail = "poweruser@gmail.com";

        public static readonly Guid ManagerUserId = Guid.Parse("3ed1c86f-9a0b-4289-9a2c-c3736f142fa0");
        public const string ManagerMobile = "07032369246";
        public const string ManagerEmail = "manager@gmail.com";

        public static readonly Guid UsersUserId = Guid.Parse("24de2be9-2e75-44c3-a1da-0d6109e40fbb");
        public const string UsersMobile = "07032369246";
        public const string usersEmail = "user@gmail.com"; 
    }
}
