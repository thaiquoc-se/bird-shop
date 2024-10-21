using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.UnitOfWork;
using Services.IServices;

namespace BirdFarmShop.Pages.Manager.WorkManagement
{
    public class EditModel : PageModel
    {
        private readonly IStaffService _staffService;
        private readonly IUnitOfWork _unitOfWork;

        public EditModel(IStaffService staffService,IUnitOfWork unitOfWork)
        {
            _staffService = staffService;
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public TblStaff TblStaff { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {

            var tblstaff = _staffService.GetWorkByStaffID(id.Value);
            if (tblstaff == null)
            {
                return NotFound();
            }
            TblStaff = tblstaff;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync(int id)
        {
            try
            {
                var check = _staffService.GetWorkByStaffID(id);
                if (check != null)
                {
                    check.EndDate = DateTime.Now;
                    check.WorkStatus = "Success";
                    _unitOfWork.Update(check);
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
