using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class DistrictDAO
    {
        private static DistrictDAO instance = null!;

        private static readonly object instanceLock = new object();

        private readonly BirdFarmShopContext _context;

        public DistrictDAO()
        {
            _context = new BirdFarmShopContext();
        }

        public static DistrictDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new DistrictDAO();
                    }
                    return instance;
                }
            }
        }
        public List<TblDistrict> GetDistricts() => _context.TblDistricts.ToList();
    }
}
