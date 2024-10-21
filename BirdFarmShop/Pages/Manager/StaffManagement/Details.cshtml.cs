using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;
using BusinessObjects.DTOs;

namespace BirdFarmShop.Pages.Manager.StaffManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IUserService _userService;

        public DetailsModel(IUserService userService)
        {
            _userService = userService;
        }

        public UserDTO TblUser { get; set; } = default!;
        public string isManager;

        public  IActionResult OnGet(int? id)
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


            var tbluser = _userService.GetUserDTOById(id.Value);
            if (tbluser == null)
            {
                return NotFound();
            }
            else 
            {
                TblUser = tbluser;
            }
            return Page();
        }
    }
}
