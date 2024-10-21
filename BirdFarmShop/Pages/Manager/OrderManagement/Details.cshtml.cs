using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.Manager.OrderManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderDetailService _orderDetailService;
        private string isManager;

        public DetailsModel(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

      public List<TblOrderDetail> TblOrder { get; set; } = default!; 

        public IActionResult OnGet(int? id)
        {
            try
            {
                isManager = HttpContext.Session.GetString("isManager")!;
                if (isManager != "MN")
                {
                    return NotFound();
                }
                if (isManager == null)
                {
                    return NotFound();
                }
            }
            catch
            {
                NotFound();
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
