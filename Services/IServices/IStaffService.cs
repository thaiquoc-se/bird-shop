﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IStaffService
    {
        List<TblStaff> GetAllWork();

        TblStaff GetWorkByStaffID(int id);

        void AddNew(TblStaff record);
    }
}
