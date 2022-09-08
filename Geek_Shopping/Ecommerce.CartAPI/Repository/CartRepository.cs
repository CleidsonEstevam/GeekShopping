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
        public async Task<bool> RemoveCoupon(string UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string UserId)
        {
            var cartHeader = await _context.CartHaders.FirstOrDefaultAsync(c => c.UserId == UserId);
            if (cartHeader != null)
            {
                _context.CartDetails.RemoveRange(_context.CartDetails.Where(c => c.CartHeaderId == cartHeader.Id));
                _context.CartHaders.Remove(cartHeader);
                await _context.SaveChangesAsync();
                
                return true;
            }

            return false;
        }

        public async Task<CartDTO> FindCartUserById(string userId)
        {
            Cart cart = new Cart()
            {
                CartHeader = await _context.CartHaders.FirstOrDefaultAsync(c => c.UserId == userId),
            }; 
            cart.CartDetails = _context.CartDetails.Where(c => c.CartHeaderId == cart.CartHeader.Id)
                                                   .Include(c => c.Product);
           
            return _mapper.Map<CartDTO>(cart);
        }

        public async Task<bool> RemoveFromCart(long cartDatailsId)
        {
            try
            {
                CartDetail cartDetail = await _context.CartDetails.FirstOrDefaultAsync(c => c.Id == cartDatailsId);
                int total = _context.CartDetails.Where(c => c.CartHeaderId == cartDetail.CartHeaderId).Count();

                _context.CartDetails.Remove(cartDetail);
                if (total == 1) 
                {
                    var cartHeaderToemove = await _context.CartHaders.FirstOrDefaultAsync(c => c.Id == cartDetail.CartHeaderId);
                    _context.CartHaders.Remove(cartHeaderToemove);

                }
                await _context.SaveChangesAsync();  

                return true;
            }
            catch (Exception)
            {

                return false;
            }     
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

            //criando cabeçalho e items do carrinho
            var cartHeader = await _context.CartHaders.AsNoTracking().FirstOrDefaultAsync(c => c.UserId == cart.CartHeader.UserId);
            if (cartHeader == null) 
            {
                _context.CartHaders.Add(cart.CartHeader);
                await _context.SaveChangesAsync();

                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                //Adicionadno null, pois, Product já foi adicionado no contexto
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
