using GeekShopping.CouponAPI.Model;
using GeekShopping.CouponAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GeekShopping.CouponAPI.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private ICouponRepository _couponRepository;


        public CouponController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository ?? throw new
                ArgumentNullException(nameof(couponRepository));
        }

        public async Task<ActionResult<CouponVo>> GetCouponByCouponCode(string id) 
        {
            var coupon = await _couponRepository.GetCouponByCouponCode(id);
            if (coupon == null) return NotFound();
            
            return Ok(coupon);  
        }
    }
}
