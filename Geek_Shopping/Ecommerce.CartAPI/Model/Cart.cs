using Ecommerce.CartAPI.Model;

namespace Ecommerce.Web.Models
{
    public class Cart
    {
        public CartHeader? CartHeader { get; set; }  
        public IEnumerable<CartDetail>? CartDetails { get; set; }
    }
}
