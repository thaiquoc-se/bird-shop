using BusinessObjects.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.IRepository;
using System.Security.Claims;

namespace BirdFarmShop.Pages
{
    public class LoginGoogleCallBackModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        private readonly BirdFarmShopContext _birdFarmShopContext;
        public LoginGoogleCallBackModel(IUserRepository userRepository, BirdFarmShopContext birdFarmShopContext)
        {
            _userRepository = userRepository;
            _birdFarmShopContext = birdFarmShopContext;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var authenticateResult = await HttpContext.AuthenticateAsync("Google");

            if (authenticateResult.Succeeded)
            {
               
                var userFullName = authenticateResult.Principal.FindFirstValue(ClaimTypes.Name);
                var userEmail = authenticateResult.Principal.FindFirstValue(ClaimTypes.Email);
                var address = authenticateResult.Principal.FindFirstValue(ClaimTypes.StreetAddress);
                var district = authenticateResult.Principal.FindFirstValue(ClaimTypes.Locality);
                var phone = authenticateResult.Principal.FindFirstValue(ClaimTypes.HomePhone);
                var image = authenticateResult.Principal.FindFirstValue("image");

                var checkUserExisted = _birdFarmShopContext.TblUsers.Where(u => u.Email.Equals(userEmail)).SingleOrDefault();

                if (checkUserExisted != null)
                {
                    HttpContext.Session.SetInt32("UserID",checkUserExisted.UserId);
                    return RedirectToPage("User/Profile");
                }
                TblUser user = new TblUser()
                {
                    FullName = userFullName,
                    Email = userEmail,
                    RoleId = "US",
                    UserAddress =address,
                    UserStatus = true,
                    Phone = phone,
                    Pass ="@1"
                };
                _birdFarmShopContext.TblUsers.Add(user);
                _birdFarmShopContext.SaveChanges();

                var check = _userRepository.GetUserByEmail(user.Email);
                HttpContext.Session.SetInt32("UserID", check.UserId);
                return RedirectToPage("User/Profile");
            }
            else
            {
                // Xử lý lỗi đăng nhập Google ở đây

                return RedirectToPage("/Login");
            }
        }
    }
}
