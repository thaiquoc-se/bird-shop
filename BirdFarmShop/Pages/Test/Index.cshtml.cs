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
    public class IndexModel : PageModel
    {
        private readonly BusinessObjects.Models.BirdFarmShopContext _context;

        public IndexModel(BusinessObjects.Models.BirdFarmShopContext context)
        {
            _context = context;
        }

        public IList<TblUser> TblUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TblUsers != null)
            {
                TblUser = await _context.TblUsers
                .Include(t => t.District)
                .Include(t => t.Role)
                .Include(t => t.Ward).ToListAsync();
            }
        }
    }
}
