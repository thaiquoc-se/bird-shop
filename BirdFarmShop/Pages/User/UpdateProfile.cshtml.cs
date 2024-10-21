using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.User
{
    public class UpdateProfileModel : PageModel
    {
        private readonly IDistrictService _districtService;
        private readonly IWardService _wardService;
        private readonly IUserService _userService;
        public UpdateProfileModel(IDistrictService districtService, IWardService wardService, IUserService userService)
        {
            _districtService = districtService;
            _wardService = wardService;
            _userService = userService;

        }

        [BindProperty]
        public TblUser TblUser { get; set; } = default!;
        public int UserId;
        public IActionResult OnGet(int? id)
        {
            try
            {
                UserId = (int)HttpContext.Session.GetInt32("UserID")!;
                if (UserId != id.Value )
                {
                    return BadRequest();
                }
            }
            catch
            {
                return NotFound();
            }

            var tbluser = _userService.GetUserByID(id.Value);
            if (tbluser == null)
            {
                return NotFound();
            }
            TblUser = tbluser;
            ViewData["DistrictName"] = new SelectList(_districtService.GetDistricts(), "DistrictId", "DistrictName");
            ViewData["WardName"] = new SelectList(_wardService.GetWards(), "WardId", "WardName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            try
            {
                _userService.Update(TblUser);
            }
            catch
            {
                OnGet(TblUser.UserId);
                return Page();
            }

            

            return RedirectToPage("Profile");
        }

        
    }
}
