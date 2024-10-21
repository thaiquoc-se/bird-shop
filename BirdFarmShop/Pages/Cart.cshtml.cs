using BirdFarmShop.Entities;
using BirdFarmShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.IServices;

namespace BirdFarmShop.Pages
{
    public class CartModel : PageModel
    {
        private readonly IBirdService _birdService;
        public CartModel(IBirdService birdService) 
        {
            _birdService = birdService;
        }
        public List<Item> cart { get; set; }
        public decimal?  Total { get; set; }

        public IActionResult OnGet()
        {
            try
            {
                cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                if(cart == null) 
                {
                    return RedirectToPage("CartEmpty");
                }
                Total = cart.Sum(i => i.bird.Price * i.Quantity);
            }
            catch
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnGetAddToCart(int id)
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item
                {
                    bird = _birdService.GetBirdByID(id),
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new Item
                    {
                        bird = _birdService.GetBirdByID(id),
                        Quantity = 1
                    });
                }
                else
                {
                    cart[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToPage("Cart");
        }
        public IActionResult OnGetDelete(int id)
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Cart");
        }

        public IActionResult OnPostUpdate(int[] quantities)
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            try
            {
                for (var i = 0; i < cart.Count; i++)
                {
                    cart[i].Quantity = quantities[i];
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                return RedirectToPage("Cart");
            }
            catch
            {
                return RedirectToPage("Cart");
            }
            
        }

        private int Exists(List<Item> cart, int id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].bird.BirdId == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
