using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VueCrudSolution.Data.Models;
using VueCrudSolution.Shared.DataAccess.Interfaces;
using VueCrudSolution.Shared.DataAccess.Repository;
using VueCrudSolution.Shared.Service.Interfaces;

namespace VueCrudSolution.Shared.Service.Repository
{
    public class AddressService : Service<UserAddress>, IAddressService
    {
        public AddressService(IUnitOfWork iuow) : base(iuow)
        {
        }
    }
}
