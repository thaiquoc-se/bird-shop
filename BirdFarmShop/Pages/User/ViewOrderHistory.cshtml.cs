using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;
using Microsoft.AspNetCore.SignalR;
using BusinessObjects.DTOs;

namespace BirdFarmShop.Pages.User
{
    public class ViewOrderHistoryModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        public int userId;

        public ViewOrderHistoryModel(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        public IList<TblOrder> TblOrder { get;set; } = default!;
        public UserDTO TblUserDTO { get; set; }
        public string EmptyCart { get; private set; }

        public IActionResult OnGet(int? id)
        {
            try
            {
                userId = (int)HttpContext.Session.GetInt32("UserID")!;
            }
            catch
            {
                return NotFound();  
            }
            var tblorder = _orderService.GetAllOrders().Where(o => o.UserId == id).ToList();
            try
            {
                var check = _orderService.GetAllOrders().Where(o => o.UserId == id).FirstOrDefault();
                if (check == null)
                {
                    EmptyCart = "You Not Have Any Order History";
                    return Page();
                }
                if (check.UserId != id)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return NotFound();
            }
            if (tblorder == null)
            {
                EmptyCart = "You Not Have Any Order History";
                return Page();
            }
            else
            {
                TblOrder = tblorder;
            }
            TblOrder = _orderService.GetAllOrders().Where(u => u.UserId == id).ToList();
            userId = (int)HttpContext.Session.GetInt32("UserID")!;
            TblUserDTO = _userService.GetUserDTOById(userId);
            return Page();
        }
    }
}
