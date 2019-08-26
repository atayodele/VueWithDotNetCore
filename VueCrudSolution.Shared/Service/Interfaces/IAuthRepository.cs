using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VueCrudSolution.Data.Models;

namespace VueCrudSolution.Shared.Service.Interfaces
{
    public interface IAuthRepository
    {
        Task<IEnumerable<ApplicationIdentityRole>> GetRoles();
        Task<ApplicationIdentityRole> GetRole(Guid id);
    }
}
