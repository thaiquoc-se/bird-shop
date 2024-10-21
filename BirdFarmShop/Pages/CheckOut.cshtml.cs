using BirdFarmShop.Entities;
using BirdFarmShop.Helpers;
using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services.IServices;
using Services.UnitOfWork;

namespace BirdFarmShop.Pages
{
    public class CheckOutModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IBirdService _birdService;
        private readonly IUserService _userService;
        public CheckOutModel(IOrderService orderService, IUnitOfWork unitOfWork, IOrderDetailService orderDetailService, IBirdService birdService, IUserService userService) 
        {
            _orderDetailService = orderDetailService;
            _unitOfWork = unitOfWork;
            _birdService = birdService;
            _orderService = orderService;
            _userService = userService;
        }

        [BindProperty]
        public UserDTO TblUser { get; set; } = default!;
        public List<Item> cart { get; set; }
        public decimal? Total { get; set; }
        public string Msg { get; private set; }
        public string EmptyMsg { get; private set; }
        public int UserId;
        public string errorQuantity;

        public IActionResult OnGet()
        {
            try
            {
                UserId = (int)HttpContext.Session.GetInt32("UserID")!;
            }
            catch
            {
                Msg = "You must be login to continute this action";
                cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                return Page();
            }
            var tbluser = _userService.GetUserDTOById(UserId);
            if (tbluser == null)
            {
                return NotFound();
            }
            TblUser = tbluser;
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            return Page();
        }
        public IActionResult OnPost()
        {
            try
            {
                UserId = (int)HttpContext.Session.GetInt32("UserID")!;
            }catch
            {
                return RedirectToPage("Login");
            }
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if(cart.Count <= 0)
            {
                EmptyMsg = "You do not have any Bird in your Cart";
                return Page();
            }
            Total = cart.Sum(i => i.bird.Price * i.Quantity);

            var order = new TblOrder()
            {
                UserId = UserId,
                ReasonContent = $"Số điện thoại người nhận: {TblUser.Phone},Tên Người nhận: {TblUser.FullName}",
                TypeOrder = "Shopping",
                OrderStatus = "Processing",
                StartDate = DateTime.Now,
                EndDate = null,
                ShipAddress = TblUser.UserAddress!
            };
            _orderService.AddNewOrder(order);

            foreach (var item in cart)
            {
                var orderDetail = new TblOrderDetail()
                {
                    OrderId = order.OrderId,
                    BirdId = item.bird.BirdId,
                    Quantity = item.Quantity,
                    TotalPrice = item.Quantity * item.bird.Price,
                    CostsIncurred = ""
                };
                var checkQuantity = _birdService.GetBirdByID(item.bird.BirdId);
                if (checkQuantity != null && checkQuantity.Quantity > 0 && checkQuantity.Quantity > item.Quantity) 
                {
                    checkQuantity.Quantity -= item.Quantity;
                    _unitOfWork.Update(checkQuantity);
                    _unitOfWork.SaveChanges();
                }
                else
                {
                    errorQuantity = "This Bird is out of Stock";
                    return Page();
                }
                _orderDetailService.AddNewOrderDetail(orderDetail);
            }
            HttpContext.Session.Remove("cart");

            return RedirectToPage("ShowAllBirds");
        }
    }
}
