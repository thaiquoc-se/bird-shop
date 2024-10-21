using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;
using Services.UnitOfWork;
using Services.Services;

namespace BirdFarmShop.Pages.Manager.WorkManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IStaffService _staffService;
        private readonly IUnitOfWork _unitOfWork;
        private string isManager;
        public DeleteModel(IStaffService staffService, IUnitOfWork unitOfWork)
        {
           _staffService = staffService;
           _unitOfWork = unitOfWork;
        }

        [BindProperty]
      public TblStaff TblStaff { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            try
            {
                isManager = HttpContext.Session.GetString("isManager")!;
                if (isManager != "MN")
                {
                    return NotFound();
                }
                if (isManager == null)
                {
                    return NotFound();
                }
            }
            catch
            {
                NotFound();
            }

            var tbstaff = _staffService.GetAllWork().Where(s => s.StaffId == id).SingleOrDefault();

            if (tbstaff == null)
            {
                return NotFound();
            }
            else
            {
                TblStaff = tbstaff;
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            try
            {
                var staff = _staffService.GetAllWork().Where(s => s.StaffId == id).SingleOrDefault();
                if (staff != null)
                {
                    staff.EndDate = DateTime.Now;
                    staff.WorkStatus = "Cancel";
                    _unitOfWork.Update(staff);
                    _unitOfWork.SaveChanges();
                }
            }
            catch
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
