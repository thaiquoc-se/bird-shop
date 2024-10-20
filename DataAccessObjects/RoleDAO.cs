using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class RoleDAO
    {
        private static RoleDAO instance = null!;

        private static readonly object instanceLock = new object();

        private readonly BirdFarmShopContext _context;

        public RoleDAO()
        {
            _context = new BirdFarmShopContext();
        }

        public static RoleDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoleDAO();
                    }
                    return instance;
                }
            }
        }

        public List<TblRole> GetRoles() => _context.TblRoles.ToList();
    }
}
