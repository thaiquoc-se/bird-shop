using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;
using Services.Services;
using BusinessObjects.DTOs;

namespace BirdFarmShop.Pages.Manager.OrderManagement
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private string isManager;

        public IndexModel(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        public IList<TblOrder> TblOrder { get;set; } = default!;
        public int UserId { get; private set; }
        public UserDTO TblUserDTO { get; set; }
        public IActionResult OnGet()
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
            TblOrder = _orderService.GetAllOrders();
            UserId = (int)HttpContext.Session.GetInt32("UserID")!;
            TblUserDTO = _userService.GetUserDTOById(UserId);
            return Page();
        }
    }
}
