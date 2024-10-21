using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;
using Services.UnitOfWork;

namespace BirdFarmShop.Pages.Manager.StaffManagement
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObjects.Models.BirdFarmShopContext _context;

        public DeleteModel(BusinessObjects.Models.BirdFarmShopContext context)
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

            var tbluser = await _context.TblUsers.FirstOrDefaultAsync(m => m.UserId == id);

            if (tbluser == null)
            {
                return NotFound();
            }
            else
            {
                TblUser = tbluser;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TblUsers == null)
            {
                return NotFound();
            }
            var tbluser = await _context.TblUsers.FindAsync(id);

            if (tbluser != null)
            {
                TblUser = tbluser;
                _context.TblUsers.Remove(TblUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
