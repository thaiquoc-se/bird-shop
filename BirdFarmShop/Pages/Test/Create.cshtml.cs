using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;

namespace BirdFarmShop.Pages.Test
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObjects.Models.BirdFarmShopContext _context;

        public CreateModel(BusinessObjects.Models.BirdFarmShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DistrictId"] = new SelectList(_context.TblDistricts, "DistrictId", "DistrictId");
        ViewData["RoleId"] = new SelectList(_context.TblRoles, "RoleId", "RoleId");
        ViewData["WardId"] = new SelectList(_context.TblWards, "WardId", "WardId");
            return Page();
        }

        [BindProperty]
        public TblUser TblUser { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          
            _context.TblUsers.Add(TblUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
