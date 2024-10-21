using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace BirdFarmShop.Pages.Test
{
    public class CheckInformationModel : PageModel
    {
        private readonly BusinessObjects.Models.BirdFarmShopContext _context;

        public CheckInformationModel(BusinessObjects.Models.BirdFarmShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblUser TblUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TblUsers == null)
            {
                return NotFound();
            }

            var tbluser =  await _context.TblUsers.FirstOrDefaultAsync(m => m.UserId == id);
            if (tbluser == null)
            {
                return NotFound();
            }
            TblUser = tbluser;
           ViewData["DistrictId"] = new SelectList(_context.TblDistricts, "DistrictId", "DistrictId");
           ViewData["RoleId"] = new SelectList(_context.TblRoles, "RoleId", "RoleId");
           ViewData["WardId"] = new SelectList(_context.TblWards, "WardId", "WardId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUserExists(TblUser.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TblUserExists(int id)
        {
          return (_context.TblUsers?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
