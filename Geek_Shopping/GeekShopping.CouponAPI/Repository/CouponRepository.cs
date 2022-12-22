using AutoMapper;
using GeekShopping.CouponAPI.Data.ValueObjects;
using GeekShopping.CouponAPI.Model;
using GeekShopping.CouponAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GeekShopping.CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly MySQLContext _couponContext;
        private IMapper _mapper;

        public CouponRepository(MySQLContext couponContext, IMapper mapper)
        {
            _couponContext = couponContext;
            _mapper = mapper;
        }

        public async Task<CouponVO> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _couponContext.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);
            
            return _mapper.Map<CouponVO>(coupon);
        }
    }
}
