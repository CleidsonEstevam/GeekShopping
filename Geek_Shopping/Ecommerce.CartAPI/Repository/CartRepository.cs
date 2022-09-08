using AutoMapper;
using Ecommerce.CartAPI.Data.DTO;
using Ecommerce.CartAPI.Model;
using Ecommerce.CartAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDTO> FindCartUserById(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCoupon(string UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFromCart(long cartDatailsId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDTO> SaveOrUpdateCart(CartDTO cartDTO)
        {  
            Cart cart = _mapper.Map<Cart>(cartDTO);
             var product = _context.Products.FirstOrDefaultAsync(p => p.Id == cartDTO.CartDetails.FirstOrDefault().ProductId);
            if (product == null)
                _context.Products.Add(cart.CartDetails.FirstOrDefault().Product);
            await _context.SaveChangesAsync();

            var cartHeader = await _context.CartHaders.AsNoTracking().FirstOrDefaultAsync(c => c.UserId == cart.CartHeader.UserId);
            if (cartHeader == null) 
            {
                _context.CartHaders.Add(cart.CartHeader);
                await _context.SaveChangesAsync();
                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                cart.CartDetails.FirstOrDefault().Product = null;
                _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await _context.SaveChangesAsync();
            }

            return null;
        }
    }
}
