using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using BusinessObjects.DTOs;
using Services.IServices;

namespace BirdFarmShop.Pages.Admin.BirdChildrenMagement
{
    public class IndexModel : PageModel
    {

        private readonly IBirdChildrenService _birdChildrenService;
        private readonly IUserService _userService;
        public string isAdmin;

        public IndexModel(IBirdChildrenService birdChildrenService, IUserService userService)
        {
            _birdChildrenService = birdChildrenService;
            _userService = userService;
        }

        public IList<Tblchildrenbird> Tblchildrenbird { get; set; } = default!;
        public int UserId { get; private set; }
        public UserDTO TblUserDTO { get; set; }
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
            Tblchildrenbird = _birdChildrenService.GetAllBirdChildren();
            UserId = (int)HttpContext.Session.GetInt32("UserID")!;
            TblUserDTO = _userService.GetUserDTOById(UserId);
            return Page();
        }
    }
}
