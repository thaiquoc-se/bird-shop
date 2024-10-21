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

namespace BirdFarmShop.Pages.Manager.WorkManagement
{
    public class IndexModel : PageModel
    {
        private readonly IStaffService _staffService;
        private readonly IUserService _userService;
        private string isManager;
        public IndexModel(IStaffService staffService, IUserService userService)
        {
            _staffService = staffService;
            _userService = userService;
        }

        public IList<TblStaff> TblStaff { get;set; } = default!;
        public int UserId { get; private set; }
        public UserDTO TblUserDTO { get; set; }
        public IActionResult OnGet()
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
            TblStaff = _staffService.GetAllWork();
            UserId = (int)HttpContext.Session.GetInt32("UserID")!;
            TblUserDTO = _userService.GetUserDTOById(UserId);
            return Page();
        }

    }
}
