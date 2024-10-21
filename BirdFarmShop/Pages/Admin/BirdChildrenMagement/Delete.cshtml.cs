using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace BirdFarmShop.Pages.Admin.BirdChildrenMagement
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObjects.Models.BirdFarmShopContext _context;

        public DeleteModel(BusinessObjects.Models.BirdFarmShopContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Tblchildrenbird Tblchildrenbird { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tblchildrenbirds == null)
            {
                return NotFound();
            }

            var tblchildrenbird = await _context.Tblchildrenbirds.FirstOrDefaultAsync(m => m.ChildrenBirdId == id);

            if (tblchildrenbird == null)
            {
                return NotFound();
            }
            else 
            {
                Tblchildrenbird = tblchildrenbird;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tblchildrenbirds == null)
            {
                return NotFound();
            }
            var tblchildrenbird = await _context.Tblchildrenbirds.FindAsync(id);

            if (tblchildrenbird != null)
            {
                Tblchildrenbird = tblchildrenbird;
                _context.Tblchildrenbirds.Remove(Tblchildrenbird);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
