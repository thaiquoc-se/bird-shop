using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.IServices;
using Services.UnitOfWork;

namespace BirdFarmShop.Pages.Manager.OrderManagement
{
    public class SuccessModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IUnitOfWork _unitOfWork;
        private string isManager;

        public SuccessModel(IOrderService orderService, IUnitOfWork unitOfWork)
        {
            _orderService = orderService;
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public TblOrder TblOrder { get; set; } = default!;

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

            var tblorder = _orderService.GetAllOrders().Where(o => o.OrderId == id).SingleOrDefault();

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

        public IActionResult OnPost(int? id)
        {
            try
            {
                var order = _orderService.GetAllOrders().Where(o => o.OrderId == id).SingleOrDefault();
                if (order != null)
                {
                    order.EndDate = DateTime.Now;
                    order.OrderStatus = "Success";
                    _unitOfWork.Update(order);
                    _unitOfWork.SaveChanges();
                }
            }
            catch
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

