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

namespace BirdFarmShop.Pages.Staff.ViewWork
{
    public class ViewWorkModel : PageModel
    {
        private readonly IStaffService _staffService;
        private readonly IUserService _userService;
        private string isStaff;
        public ViewWorkModel(IStaffService staffService, IUserService userService)
        {
            _staffService = staffService;
            _userService = userService;
        }

        public IList<TblStaff> TblStaff { get;set; } = default!;
        public int UserID { get; private set; }
        public UserDTO TblUserDTO { get; set; }
        public IActionResult OnGet()
        {
            try
            {
                UserID = (int)HttpContext.Session.GetInt32("UserID")!;
            }
            catch
            {
                return NotFound();
            }
            UserID = (int)HttpContext.Session.GetInt32("UserID")!;
            TblUserDTO = _userService.GetUserDTOById(UserID);
            TblStaff = _staffService.GetAllWork().Where(s => s.UserId == UserID).ToList();
            return Page();
        }
    }
}
