using BusinessObjects.Models;
using DataAccessObjects;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class RoleRepository : IRoleRepository
    {
        public List<TblRole> GetRoles() => RoleDAO.Instance.GetRoles();
        
    }
}
