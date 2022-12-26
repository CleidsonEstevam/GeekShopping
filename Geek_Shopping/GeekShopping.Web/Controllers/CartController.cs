using GeekShopping.Web.Models;
using GeekShopping.Web.Services.Interfaces;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GeekShopping.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly ICouponService _couponService;


        public CartController(IProductService productService, ICartService cartService, ICouponService couponService)
        {
            _productService = productService;
            _cartService = cartService;
            _couponService = couponService;
        }

        public async Task<IActionResult> CartIndex()
        {
            return View(await FindUserCart());
        }

        public async Task<IActionResult> Remove(int id) 
        {
            //Pegar Token e UserId
            var token = await HttpContext.GetTokenAsync("access_token");
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            //Carregar delete no response
            var response = await _cartService.RemoveFromCart(id, token);
            if (response)
            {
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }

        private async Task<CartViewModel> FindUserCart() 
        {
            //Pegar Token e UserId
            var token = await HttpContext.GetTokenAsync("access_token");
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            //Ir buscar response com dados do carrinho 
            var response = await _cartService.FindCartByUserId(userId, token);

            //Somar itens e adicionar total
            if (response?.CartHeader != null) 
            {
                if (!string.IsNullOrEmpty(response.CartHeader.CouponCode)) 
                {
                    string code = response.CartHeader.CouponCode;
                    var coupon = await _couponService.GetCoupon(code, token);
                    if (coupon?.CouponCode != null) 
                    {
                        response.CartHeader.DiscountTotal = coupon.DiscountAmount; 
                    }
                
                }
                foreach (var detail in response.CartDetails) 
                {
                    response.CartHeader.PurchaseAmount += (detail.Product.Price * detail.Count);
                }   
                response.CartHeader.PurchaseAmount -= response.CartHeader.DiscountTotal;
            }
            return response;
        }

        [HttpPost]
        [ActionName("ApplyCoupon")]
        public async Task<IActionResult> ApplyCoupon(CartViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartService.ApplyCoupon(model, token);

            if (response)
            {
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }

        [HttpPost]
        [ActionName("RemoveCoupon")]
        public async Task<IActionResult> RemoveCoupon()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartService.RemoveCoupon(userId, token);

            if (response)
            {
                return RedirectToAction(nameof(CartIndex));
            }
            return View();
        }
    }
}
