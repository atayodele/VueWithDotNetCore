using System;
using System.Collections.Generic;

namespace VueCrudSolution.Data.Models.Extensions
{
    public static class RoleHelpers
    {
        public static Guid SYS_ADMIN_ID() => Guid.Parse("a1b6b6b0-0825-4975-a93d-df3dc86f8cc7");
        public const string SYS_ADMIN = nameof(SYS_ADMIN);
        public static Guid SUPER_ADMIN_ID() => Guid.Parse("0718ddef-4067-4f29-aaa1-98c1548c1807");
        public const string SUPER_ADMIN = nameof(SUPER_ADMIN);
        public static Guid ADMIN_ID() => Guid.Parse("5869ab93-81da-419b-b5ad-41a7bc82cae8");
        public const string ADMIN = nameof(ADMIN);
        public static Guid POWER_USER_ID() => Guid.Parse("e4410972-f20a-4d07-afdb-c61550e3dd44");
        public const string POWER_USER = nameof(POWER_USER);
        public static Guid MANAGER_ID() => Guid.Parse("c6072997-237f-4ec2-a2b9-8c4084553d76");
        public const string MANAGER = nameof(MANAGER);
        public static Guid USERS_ID() => Guid.Parse("d5bc65ff-6bbf-4e95-a00c-03485e5952cf");
        public const string USERS = nameof(USERS);
        public static List<string> GetAll()
        {
            return new List<string> { SYS_ADMIN, SUPER_ADMIN, ADMIN, POWER_USER, MANAGER, USERS };
        }
    }
}
