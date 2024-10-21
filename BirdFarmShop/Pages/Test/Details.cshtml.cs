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
    public class DetailsModel : PageModel
    {
        private readonly BusinessObjects.Models.BirdFarmShopContext _context;

        public DetailsModel(BusinessObjects.Models.BirdFarmShopContext context)
        {
            _context = context;
        }

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
    }
}
