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
    public class EditModel : PageModel
    {
        private readonly BusinessObjects.Models.BirdFarmShopContext _context;

        public EditModel(BusinessObjects.Models.BirdFarmShopContext context)
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

            var tblorderdetail =  await _context.TblOrderDetails.FirstOrDefaultAsync(m => m.OrderId == id);
            if (tblorderdetail == null)
            {
                return NotFound();
            }
            TblOrderDetail = tblorderdetail;
           ViewData["BirdId"] = new SelectList(_context.Birds, "BirdId", "BirdName");
           ViewData["OrderId"] = new SelectList(_context.TblOrders, "OrderId", "ShipAddress");
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

            _context.Attach(TblOrderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblOrderDetailExists(TblOrderDetail.OrderId))
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

        private bool TblOrderDetailExists(int id)
        {
          return (_context.TblOrderDetails?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
