using Ecommerce.CartAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.CartAPI.Data.DTO
{
    public class CartHeaderDTO
    {
        public long Id { get; set; }
        public string? UserId { get; set; }
        public string? CouponCode { get; set; }
    }
}
