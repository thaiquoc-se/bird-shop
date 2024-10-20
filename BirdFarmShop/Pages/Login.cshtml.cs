using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories.IRepository;
namespace BirdFarmShop.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public LoginModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        public TblUser user { get; set; } = default!;
        

      
        public IActionResult OnPost()
        {
            
            if(!string.IsNullOrWhiteSpace(user.UserName) && !string.IsNullOrWhiteSpace(user.Pass))
            {
                var check = _userRepository.checkLogin(user.UserName,user.Pass);
                if(check != null)
                {
                    if (check.RoleId.Equals("US"))
                    {
                        HttpContext.Session.SetInt32("UserID", check.UserId);
                        return RedirectToPage("User/Profile");
                    }
                    if (check.RoleId.Equals("AD"))
                    {
                        //HttpContext.Session.SetString("isAdmin");
                        return RedirectToPage("Admin/UserManagement/ShowUserList");
                    }
                }
                
            }



            return Page();
        }
    }
}
