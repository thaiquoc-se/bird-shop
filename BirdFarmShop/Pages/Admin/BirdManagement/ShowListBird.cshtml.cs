using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.IServices;

namespace BirdFarmShop.Pages.Admin.BirdManagement
{
    public class ShowListBirdModel : PageModel
    {
        private readonly IBirdService _birdService;
        private readonly IUserService _userService;
        public string isAdmin;
        public ShowListBirdModel(IBirdService birdService, IUserService userService)
        {
            _birdService = birdService;
            _userService = userService;
        }

        public IList<Bird> Bird { get; set; } = default!;
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
            Bird = _birdService.GetAllBirds();
            UserId = (int)HttpContext.Session.GetInt32("UserID")!;
            TblUserDTO = _userService.GetUserDTOById(UserId);
            return Page();
        }
    }
}

