using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickBite.Web.Models.DTO;
using QuickBite.Web.Service.IService;

namespace QuickBite.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> Index()
        {
            List<CouponDTO> coupons = new List<CouponDTO>();
            ResponseDTO response = await _couponService.GetAllCoupons();
            if (response != null && response.Success)
            {
                coupons = JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;

                if(response?.Message?.ToLower() == "Unauthorized".ToLower())
                {
                    return RedirectToAction("Login", "Auth");
                }
            }
            return View(coupons?.Where(a => a.IsActive == true));
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CouponDTO coupon)
        {
            if (ModelState.IsValid)
            {
                ResponseDTO response = await _couponService.CreateCoupon(coupon);
                if (response != null && response.Success)
                {
                    // return RedirectToAction("Index");
                    TempData["success"] = "Coupon created Successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(coupon);
        }

        public async Task<IActionResult> Delete(int couponId)
        {
            CouponDTO coupons = new CouponDTO();
            ResponseDTO response = await _couponService.GetCouponByID(couponId);
            if (response != null && response.Success)
            {
                coupons = JsonConvert.DeserializeObject<CouponDTO>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(coupons);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CouponDTO coupon)
        {
            if (ModelState.IsValid)
            {
                ResponseDTO response = await _couponService.DeleteCoupon(coupon.CouponID);
                if (response != null && response.Success)
                {
                    // return RedirectToAction("Index");
                    TempData["success"] = "Coupon deleted Successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(coupon);
        }
    }
}
