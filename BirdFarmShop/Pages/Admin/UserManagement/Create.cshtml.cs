using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.Admin.UserManagement
{
    public class CreateModel : PageModel
    {
        private readonly IDistrictService _districtService;
        private readonly IWardService _wardService;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        

        public CreateModel(IDistrictService districtService, IWardService wardService, IUserService userService, IRoleService roleService)
        {
            _districtService = districtService;
            _wardService = wardService;
            _userService = userService;
            _roleService = roleService;
        }

        public IActionResult OnGet()
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
            ViewData["DistrictName"] = new SelectList(_districtService.GetDistricts(), "DistrictId", "DistrictName");
        ViewData["RoleName"] = new SelectList(_roleService.GetRoles().Where(r => r.RoleId != "AD"), "RoleId", "RoleName");
        ViewData["WardName"] = new SelectList(_wardService.GetWards(), "WardId", "WardName");
            return Page();
        }

        [BindProperty]
        public TblUser TblUser { get; set; } = default!;
        private string isAdmin;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            
            if (!string.IsNullOrWhiteSpace(TblUser.UserName) && !string.IsNullOrWhiteSpace(TblUser.Pass))
            {
                var user = new TblUser()
                {
                    UserName = TblUser.UserName,
                    Pass = TblUser.Pass,
                    DistrictId = TblUser.DistrictId,
                    WardId = TblUser.WardId,
                    Image = "https://firebasestorage.googleapis.com/v0/b/birdfarmshop-firebase.appspot.com/o/default-avatar.png?alt=media&token=44c5ecec-0d64-402f-8f58-https://firebasestorage.googleapis.com/v0/b/birdfarmshop-firebase.appspot.com/o/default-avatar.png?alt=media&token=44c5ecec-0d64-402f-8f58-bc67824aff95&_gl=1*1pzluj4*_ga*MTc2MDE3MTQ5NS4xNjY2NDQ2MTgy*_ga_CW55HF8NVT*MTY5NzcwNjg0MS40LjEuMTY5NzcwNzM5Mi42MC4wLjA.",
                    FullName = TblUser.FullName,
                    Phone = TblUser.Phone,
                    UserAddress = TblUser.UserAddress,
                    RoleId = TblUser.RoleId,
                    Email = TblUser.Email,
                    UserStatus = true,
                };
                _userService.AddNew(user);
                return RedirectToPage("./ShowUserList");
            }
            ViewData["DistrictName"] = new SelectList(_districtService.GetDistricts(), "DistrictId", "DistrictName");
            ViewData["RoleName"] = new SelectList(_roleService.GetRoles().Where(r => r.RoleId != "AD"), "RoleId", "RoleName");
            ViewData["WardName"] = new SelectList(_wardService.GetWards(), "WardId", "WardName");
            return Page();
        }
    }
}
