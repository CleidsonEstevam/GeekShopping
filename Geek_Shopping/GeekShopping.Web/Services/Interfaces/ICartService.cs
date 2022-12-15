﻿using GeekShopping.Web.Models;
using System.Threading.Tasks;

namespace GeekShopping.Web.Services.IServices
{
    public interface ICartService
    {
        Task<CartViewModel> FindCartByUserId(string userId, string token);
        Task<CartViewModel> AddItemToCart(CartViewModel cart, string token);
        Task<CartViewModel> UpdateCart(string userId, string token);
        Task<bool> RemoveFromCart(long cartId, string token);

        Task<bool> ApplyCoupon(CartViewModel cart, string couponCode, string token);
        Task<bool> RemoveCoupon(string UserId, string token);
        Task<bool> ClearCart(string UserId, string token);
        Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token);
    }
}