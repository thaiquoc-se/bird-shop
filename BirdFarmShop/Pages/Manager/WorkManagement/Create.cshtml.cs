using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.Manager.WorkManagement
{
    public class CreateModel : PageModel
    {
         private readonly IStaffService _staffService;

         private readonly IUserService _userService;

        public CreateModel( IUserService userService,IStaffService staffService)
        {
            _userService = userService;
            _staffService = staffService;
        }

        public IActionResult OnGet()
        {
        
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers().Where(u => u.RoleId.Equals("ST")), "UserId", "FullName");
            return Page();
        }

        [BindProperty]
        public TblStaff TblStaff { get; set; } = default!;
        public int UserID { get; private set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            try
            {
                UserID = (int)HttpContext.Session.GetInt32("UserID")!;
            }
            catch 
            {
                return NotFound();
            }
            var work = new TblStaff()
            {
                UserId = TblStaff.UserId,
                WorkDescription = TblStaff.WorkDescription,
                WorkName = TblStaff.WorkName,
                Shift = TblStaff.Shift,
                WorkStatus = "Processing",
                StartDate = DateTime.Now,
                EndDate = null
            };

            _staffService.AddNew(work);
            return RedirectToPage("./Index");
        }
    }
}
