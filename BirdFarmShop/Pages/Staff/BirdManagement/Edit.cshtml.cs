using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.Staff.BirdManagement
{
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IBirdService _birdService;

        public EditModel(IUserService userService, IBirdService birdService)
        {
            _userService = userService;
            _birdService = birdService;
        }

        [BindProperty]
        public Bird Bird { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {

            var bird = _birdService.GetBirdByID(id.Value);
            if (bird == null)
            {
                return NotFound();
            }
            Bird = bird;
           ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {

            try
            {
                _birdService.Update(Bird);
            }
            catch
            {
                OnGet(Bird.BirdId);
                return Page();
            }

            return RedirectToPage("./Index");
        }

       
    }
}
