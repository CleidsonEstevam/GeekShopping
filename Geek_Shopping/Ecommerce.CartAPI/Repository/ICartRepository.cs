using Ecommerce.CartAPI.Data.DTO;
using Ecommerce.CartAPI.Model;

namespace Ecommerce.CartAPI.Repository
{
    public interface ICartRepository
    {
        Task<CartDTO> FindCartUserById(string userId);
        Task<CartDTO> SaveOrUpdateCart(CartDTO cart);
        Task<bool> RemoveFromCart(long cartDatailsId);
        Task<bool> ApplyCoupon(string userId, string couponCode);
        Task<bool> RemoveCoupon(string UserId);
        Task<bool> ClearCart(string UserId);

    }
}
