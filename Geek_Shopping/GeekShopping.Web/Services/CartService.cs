using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/cart";

        public CartService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CartViewModel> FindCartByUserId(string userId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{userId}");
            return await response.ReadContentAs<CartViewModel>();
        }
        public async Task<CartViewModel> AddItemToCart(CartViewModel cart, string token)
        {
            throw new System.NotImplementedException();
        }
        public async Task<CartViewModel> UpdateCart(string userId, string token)
        {
            throw new System.NotImplementedException();
        }
        public async Task<bool> RemoveCoupon(string UserId, string token)
        {
            throw new System.NotImplementedException();
        }
        public async Task<bool> ApplyCoupon(CartViewModel cart, string couponCode, string token)
        {
            throw new System.NotImplementedException();
        }
        public async Task<bool> RemoveFromCart(long cartId, string token)
        {
            throw new System.NotImplementedException();
        }
        public async Task<bool> ClearCart(string UserId, string token)
        {
            throw new System.NotImplementedException();
        }
        public async Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token)
        {
            throw new System.NotImplementedException();
        }
    }
}
