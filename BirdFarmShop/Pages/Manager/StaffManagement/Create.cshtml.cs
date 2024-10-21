using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Services.IServices;
using Microsoft.VisualBasic;

namespace BirdFarmShop.Pages.Manager.StaffManagement
{
    public class CreateModel : PageModel
    {
        private readonly IDistrictService _districtService;
        private readonly IWardService _wardService;
        private readonly IUserService _userService;

        public CreateModel(IDistrictService districtService, IWardService wardService, IUserService userService)
        {
            _districtService = districtService;
            _wardService = wardService;
            _userService = userService;
        }

        public IActionResult OnGet()
        {
        ViewData["DistrictName"] = new SelectList(_districtService.GetDistricts(), "DistrictId", "DistrictName");
        ViewData["WardName"] = new SelectList(_wardService.GetWards(), "WardId", "WardName");
            return Page();
        }

        [BindProperty]
        public TblUser TblUser { get; set; } = default!;
        public string Msg { get; private set; }

        public IActionResult OnPost()
        {
            var checkUser = _userService.GetAllUsers().Where(u => u.UserName == TblUser.UserName).FirstOrDefault();
            if (checkUser == null)
            {
                var staff = new TblUser()
                {
                    UserName = TblUser.UserName,
                    UserAddress = TblUser.UserAddress,
                    FullName = TblUser.FullName,
                    Pass = TblUser.Pass,
                    Phone = TblUser.Phone,
                    Image = "https://firebasestorage.googleapis.com/v0/b/birdfarmshop-firebase.appspot.com/o/default-avatar.png?alt=media&token=44c5ecec-0d64-402f-8f58-https://firebasestorage.googleapis.com/v0/b/birdfarmshop-firebase.appspot.com/o/default-avatar.png?alt=media&token=44c5ecec-0d64-402f-8f58-bc67824aff95&_gl=1*1pzluj4*_ga*MTc2MDE3MTQ5NS4xNjY2NDQ2MTgy*_ga_CW55HF8NVT*MTY5NzcwNjg0MS40LjEuMTY5NzcwNzM5Mi42MC4wLjA.",
                    Email = TblUser.Email,
                    RoleId ="ST",
                    WardId = TblUser.WardId,
                    DistrictId = TblUser.DistrictId,
                    UserStatus = TblUser.UserStatus,
                };
                _userService.AddNew(staff);
                return RedirectToPage("./Index");
            }
            else
            {
                Msg = "User Name existed";
                OnGet();
                return Page();
            }
        }
    }
}
