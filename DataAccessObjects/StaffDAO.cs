using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class StaffDAO
    {
        private static StaffDAO instance = null!;

        private static readonly object instanceLock = new object();

        private readonly BirdFarmShopContext _context;

        public StaffDAO()
        {
            _context = new BirdFarmShopContext();
        }

        public static StaffDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StaffDAO();
                    }
                    return instance;
                }
            }
        }

        public List<TblStaff> GetWorkList()
        {
            try
            {
                return _context.TblStaffs.Include(w => w.User).ToList();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TblStaff GetWorkByStaffID(int id)
        {
            try
            {
                return _context.TblStaffs.Where(st => st.StaffId == id).SingleOrDefault()!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddNew(TblStaff staff)
        {
            try
            {
                _context.TblStaffs.Add(staff);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
