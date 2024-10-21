using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace BirdFarmShop.Pages.Test
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObjects.Models.BirdFarmShopContext _context;

        public DeleteModel(BusinessObjects.Models.BirdFarmShopContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TblOrderDetail TblOrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TblOrderDetails == null)
            {
                return NotFound();
            }

            var tblorderdetail = await _context.TblOrderDetails.FirstOrDefaultAsync(m => m.OrderId == id);

            if (tblorderdetail == null)
            {
                return NotFound();
            }
            else 
            {
                TblOrderDetail = tblorderdetail;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TblOrderDetails == null)
            {
                return NotFound();
            }
            var tblorderdetail = await _context.TblOrderDetails.FindAsync(id);

            if (tblorderdetail != null)
            {
                TblOrderDetail = tblorderdetail;
                _context.TblOrderDetails.Remove(TblOrderDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
