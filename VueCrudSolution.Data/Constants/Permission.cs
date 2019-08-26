using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using VueCrudSolution.Data.Models.Extensions;

namespace VueCrudSolution.Data.Constants
{
    public enum Permission
    {
        [Category(RoleHelpers.ADMIN), Description(@"Shall create users")]
        AU_01 = 201,
        [Category(RoleHelpers.ADMIN), Description(@"Shall assign user roles")]
        AU_02 = 202,
        [Category(RoleHelpers.ADMIN), Description(@"Shall create/renew subscriptions")]
        AU_03 = 203,
        [Category(RoleHelpers.ADMIN), Description(@"Shall create and edit stores")]
        AU_04 = 204,
        [Category(RoleHelpers.ADMIN), Description(@"Shall set parameters for email notifications")]
        AU_05 = 205,
        //POWER USER
        [Category(RoleHelpers.POWER_USER), Description(@"Shall create/edit stores")]
        PU_01 = 301,
        [Category(RoleHelpers.POWER_USER), Description(@"Shall access reports (view/download) of all stores")]
        PU_02 = 302,
        [Category(RoleHelpers.POWER_USER), Description(@"Shall search/filter reports based on defined parameters")]
        PU_03 = 303,
        [Category(RoleHelpers.POWER_USER), Description(@"Shall create users")]
        PU_04 = 304,
        [Category(RoleHelpers.POWER_USER), Description(@"Shall assign user roles and permissions")]
        PU_05 = 305,
        [Category(RoleHelpers.POWER_USER), Description(@"Shall renew or change subscriptions")]
        PU_06 = 306,
        //BASIC USER
        [Category(RoleHelpers.MANAGER), Description(@"Shall access reports(view/download) of assigned stores")]
        BU_01 = 401,
        [Category(RoleHelpers.MANAGER), Description(@"Shall search/filter reports based on defined parameters")]
        BU_02 = 402,
        [Category(RoleHelpers.MANAGER), Description(@"Shall generate reports on dashboard")]
        BU_03 = 403,

    }
}
