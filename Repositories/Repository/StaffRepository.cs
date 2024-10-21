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
    public class StaffRepository : IStaffRepository
    {
        public void AddNew(TblStaff record) => StaffDAO.Instance.AddNew(record);
        

        public List<TblStaff> GetAllWork() => StaffDAO.Instance.GetWorkList();
        

        public TblStaff GetWorkByStaffID(int id) => StaffDAO.Instance.GetWorkByStaffID(id);
        
    }
}
