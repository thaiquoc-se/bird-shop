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

namespace BirdFarmShop.Pages.Admin.UserManagement
{
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IWardService _wardService;
        private readonly IDistrictService _districtService;
        public EditModel(IUserService userService, IWardService wardService, IDistrictService districtService)
        {
            _userService = userService;
            _wardService = wardService;
            _districtService = districtService;
        }

        [BindProperty]
        public TblUser TblUser { get; set; } = default!;
        public string isAdmin;
        public IActionResult OnGet(int? id)
        {
            try
            {
                isAdmin = HttpContext.Session.GetString("isAdmin")!;
                if (isAdmin != "AD")
                {
                    return NotFound();
                }
                if (isAdmin == null)
                {
                    return NotFound();
                }
            }
            catch
            {
                NotFound();
            }

            var tbluser = _userService.GetUserByID(id.Value);
            if (tbluser.RoleId == "AD")
            {
                return BadRequest();
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
            _userService.Update(TblUser);
            return RedirectToPage("./ShowUserList");
        }
    }
}
