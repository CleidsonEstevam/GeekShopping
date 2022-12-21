using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GeekShopping.Web.Controllers
{
    public class CartController1 : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public CartController1(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public async Task<IActionResult> CartIndex()
        {
            return View();
        }
    }
}
