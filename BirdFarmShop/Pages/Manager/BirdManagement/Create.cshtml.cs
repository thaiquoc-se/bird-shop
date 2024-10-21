using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.Manager.BirdManagement
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IBirdService _birdService;
        private string isManager;

        public CreateModel(IUserService userService, IBirdService birdService)
        {
            _userService = userService;
            _birdService = birdService;
        }

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
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "FullName");
            return Page();
        }

        [BindProperty]
        public Bird Bird { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {

            try
            {
                _birdService.AddNew(Bird);
            }
            catch
            {
                ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "FullName");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
