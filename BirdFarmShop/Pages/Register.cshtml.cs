using BusinessObjects.Models;
using BusinessObjects.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repositories.IRepository;
using Services.IServices;

namespace BirdFarmShop.Pages
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly IDistrictService _districtService;
        private readonly IWardService _wardService;
        private readonly IUserService _userService;
        public RegisterModel(IDistrictService districtService, IWardService wardService, IUserService userService)
        {
            _districtService = districtService;
            _wardService = wardService;
            _userService = userService;
        }

        public RegisterViewModel TblUser { get; set; } = default!;
        public string ErrorMessage = null!;
        public IActionResult OnGet()
        {
            ViewData["DistrictName"] = new SelectList(_districtService.GetDistricts(), "DistrictId", "DistrictName");
            ViewData["WardName"] = new SelectList(_wardService.GetWards(), "WardId", "WardName");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (TblUser!.Pass != TblUser.ConfirmPass)
            {
                ViewData["DistrictName"] = new SelectList(_districtService.GetDistricts(), "DistrictId", "DistrictName");
                ViewData["WardName"] = new SelectList(_wardService.GetWards(), "WardId", "WardName");
                ErrorMessage = "Password and Confirm Password do not match.";
                return Page();
            }
            
            if(!string.IsNullOrWhiteSpace(TblUser.UserName) && !string.IsNullOrWhiteSpace(TblUser.Pass))
            {
                var checkUserName = _userService.GetAllUsers().Where(u => u.UserName.Equals(TblUser.UserName)).FirstOrDefault();

                if (checkUserName != null)
                {
                    ErrorMessage = "UserName Existed";
                    return Page();
                }
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
                    RoleId ="US",
                    Email = TblUser.Email,
                    UserStatus = true,
                };
                _userService.AddNew(user);
                return RedirectToPage("./Login");
            }
            ViewData["DistrictName"] = new SelectList(_districtService.GetDistricts(), "DistrictId", "DistrictName");
            ViewData["WardName"] = new SelectList(_wardService.GetWards(), "WardId", "WardName");
            return Page();
        }
    }
}
