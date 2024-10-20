using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class WardDAO
    {
        private static WardDAO instance = null!;

        private static readonly object instanceLock = new object();

        private readonly BirdFarmShopContext _context;

        public WardDAO()
        {
            _context = new BirdFarmShopContext();
        }

        public static WardDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new WardDAO();
                    }
                    return instance;
                }
            }
        }
        public List<TblWard> GetWards() => _context.TblWards.ToList();
    }
}
