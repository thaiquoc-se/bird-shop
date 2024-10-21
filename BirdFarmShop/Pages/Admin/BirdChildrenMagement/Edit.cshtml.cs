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

namespace BirdFarmShop.Pages.Admin.BirdChildrenMagement
{
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IBirdChildrenService _birdChildrenService;
        private string isAdmin;

        public EditModel(IUserService userService, IBirdChildrenService birdChildrenService)
        {
            _userService = userService;
            _birdChildrenService = birdChildrenService;
        }

        [BindProperty]
        public Tblchildrenbird Tblchildrenbird { get; set; } = default!;

        public IActionResult OnGet(int? id)
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

            var birdChildren = _birdChildrenService.GetBirdChildrenByID(id.Value);
            if (birdChildren == null)
            {
                return NotFound();
            }
            Tblchildrenbird = birdChildren;
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {

            try
            {
                _birdChildrenService.Update(Tblchildrenbird);
            }
            catch
            {
                OnGet(Tblchildrenbird.ChildrenBirdId);
                return Page();
            }

            return RedirectToPage("./ShowListBird");
        }

    }
}
