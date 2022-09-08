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

            //verifica se o produto esta salvo
             var product = _context.Products.FirstOrDefaultAsync(p => p.Id == cartDTO.CartDetails.FirstOrDefault().ProductId);
            //se não estiver adiciona 
            if (product == null)
                _context.Products.Add(cart.CartDetails.FirstOrDefault().Product);
            await _context.SaveChangesAsync();

            //criando cabeçalho e items do carrinhp
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
            else 
            {
                //verifica se o detalhe é do mesmo produto
                var cartDatail = await _context.CartDetails.AsNoTracking().FirstOrDefaultAsync(p => p.ProductId == cartDTO.CartDetails.FirstOrDefault().ProductId && p.CartHeaderId == cartHeader.Id);
                
                if (cartDatail == null)
                {
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                    cart.CartDetails.FirstOrDefault().Product = null;
                    _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
                else 
                {
                    cart.CartDetails.FirstOrDefault().Product = null;
                    cart.CartDetails.FirstOrDefault().Count += cartDatail.Count;
                    cart.CartDetails.FirstOrDefault().Id = cartDatail.Id;
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartDatail.CartHeaderId;

                    _context.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
            }

            return _mapper.Map<CartDTO>(cart);
        }
    }
}
