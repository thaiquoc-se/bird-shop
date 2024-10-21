using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.Admin.OrderManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderDetailService _orderDetailService;
        private string isAdmin;

        public DetailsModel(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

      public List<TblOrderDetail> TblOrder { get; set; } = default!; 

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
                return NotFound();
            }

            var tblorder = _orderDetailService.GetOrderDetailByID(id.Value);
            if (tblorder == null)
            {
                return NotFound();
            }
            else 
            {
                TblOrder = tblorder;
            }
            return Page();
        }
    }
}
