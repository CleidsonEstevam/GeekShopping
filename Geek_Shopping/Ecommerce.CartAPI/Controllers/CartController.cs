using Ecommerce.CartAPI.Data.DTO;
using Ecommerce.CartAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.CartAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository)); ;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<CartDTO> SaveOrUpdateCart(CartDTO cartDTO)
        {
            
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<CartDTO>> FindById(string userId)
        {
            var cart = await _repository.FindCartUserById(userId);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        public async Task<bool> ClearCart(string UserId)
        {
            
        }

        public async Task<bool> RemoveFromCart(long cartDatailsId)
        {

        }
    }
}
