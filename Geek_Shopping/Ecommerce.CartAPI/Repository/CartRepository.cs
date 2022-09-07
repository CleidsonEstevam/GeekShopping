using AutoMapper;
using Ecommerce.CartAPI.Data.DTO;
using Ecommerce.CartAPI.Model.Context;

namespace Ecommerce.CartAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public CartRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ClearCart(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<CartDTO> FindCartUserById(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveCoupon(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFromCart(long cartDatailsId)
        {
            throw new NotImplementedException();
        }

        public Task<CartDTO> SaveOrUpdateCart(CartDTO cart)
        {
            throw new NotImplementedException();
        }
    }
}
