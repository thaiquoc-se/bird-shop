using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.Manager.WorkManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IStaffService _staffService;

        public DetailsModel(IStaffService staffService)
        {
            _staffService = staffService;
        }

      public TblStaff TblStaff { get; set; } = default!; 

        public IActionResult OnGet(int? id)
        {

            var tblstaff = _staffService.GetWorkByStaffID(id.Value);
            if (tblstaff == null)
            {
                return NotFound();
            }
            else 
            {
                TblStaff = tblstaff;
            }
            return Page();
        }
    }
}
