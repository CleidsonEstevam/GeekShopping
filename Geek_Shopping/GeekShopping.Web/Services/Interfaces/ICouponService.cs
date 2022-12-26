using GeekShopping.Web.Models;
using System.Threading.Tasks;

namespace GeekShopping.Web.Services.Interfaces
{
    public interface ICouponService
    {
        Task<CouponViewModel> GetCoupon(string code, string token);
    }
}
