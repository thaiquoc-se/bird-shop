using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.Admin.BirdChildrenMagement
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IBirdChildrenService _birdChildrenService;
        private string isAdmin;

        public CreateModel(IUserService userService, IBirdChildrenService birdChildrenService)
        {
            _userService = userService;
            _birdChildrenService = birdChildrenService;
        }

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
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "FullName");
            return Page();
        }

        [BindProperty]
        public Tblchildrenbird Tblchildrenbird { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            try
            {
                _birdChildrenService.AddNew(Tblchildrenbird);
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
