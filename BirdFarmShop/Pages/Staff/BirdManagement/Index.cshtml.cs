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
using Services.Services;

namespace BirdFarmShop.Pages.Staff.BirdManagement
{
    public class IndexModel : PageModel
    {
        private readonly IBirdService _birdService;
        private readonly IUserService _userService;
        private string isStaff;
        public IndexModel(IBirdService birdService, IUserService userService)
        {
            _birdService = birdService;
            _userService = userService;
        }

        public IList<Bird> Bird { get;set; } = default!;
        public int UserId { get; private set; }
        public UserDTO TblUserDTO { get; set; }
        public IActionResult OnGet()
        {
            try
            {
                isStaff = HttpContext.Session.GetString("isStaff")!;
                if (isStaff != "ST")
                {
                    return NotFound();
                }
                if (isStaff == null)
                {
                    return NotFound();
                }
            }
            catch
            {
                NotFound();
            }
            Bird = _birdService.GetAllBirds();
            UserId = (int)HttpContext.Session.GetInt32("UserID")!;
            TblUserDTO = _userService.GetUserDTOById(UserId);
            return Page();

        }
    }
}
