using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IStaffRepository
    {
        List<TblStaff> GetAllWork();

        TblStaff GetWorkByStaffID(int id);

        void AddNew(TblStaff record);
    }
}
