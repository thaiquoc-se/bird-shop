using BusinessObjects.Models;
using Repositories.IRepository;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        public StaffService(IStaffRepository staffRepository) 
        {
            _staffRepository = staffRepository;
        }
        public void AddNew(TblStaff record) => _staffRepository.AddNew(record);
       

        public List<TblStaff> GetAllWork() => _staffRepository.GetAllWork();


        public TblStaff GetWorkByStaffID(int id) => _staffRepository.GetWorkByStaffID(id);
        
    }
}
