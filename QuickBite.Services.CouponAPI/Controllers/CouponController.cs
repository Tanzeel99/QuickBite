using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickBite.Services.CouponAPI.Data;
using QuickBite.Services.CouponAPI.Models;
using QuickBite.Services.CouponAPI.Models.DTO;

namespace QuickBite.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CouponController : ControllerBase
    {
        private readonly CouponDBContext _db;
        private ResponseDTO response;
        private IMapper _mapper;
        public CouponController(CouponDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            response = new ResponseDTO();
        }


        [HttpGet]
        [Route("GetAllCoupon")]
        public ResponseDTO GetAll()
        {
            try
            {
                var coupons = _db.Coupons
    .Where(a => a.IsActive && !string.IsNullOrEmpty(a.CouponCode) && a.CouponCode.Length > 1)
    .AsEnumerable() // Switches to LINQ-to-Objects (in-memory)
    .OrderBy(s => int.Parse(s.CouponCode.Substring(1)))
    .ToList();
                response.Result = _mapper.Map<List<CouponDTO>>(coupons);
            }
            catch (Exception e)
            {
                response.Result = e;
                response.Message = e.Message;
                response.Success = false;
            }
            return response;
        }

        [HttpGet]
        [Route("GetCouponById/{id:int}")]
        public ResponseDTO GetCoupon(int id)
        {
            try
            {
                var coupon = _db.Coupons.FirstOrDefault(a => a.CouponID == id);

                //Instead of doing this we will be using AutoMapper to map to DTO
                /*CouponDTO couponDTO = new CouponDTO()
                {
                    CouponCode = coupon.CouponCode,
                    DiscountAmount = coupon.DiscountAmount,
                    MinAmount = coupon.MinAmount,
                };*/

                response.Result = _mapper.Map<CouponDTO>(coupon);
            }
            catch (Exception e)
            {
                response.Result = e;
                response.Message = e.Message;
                response.Success = false;
            }
            return response;
        }

        [HttpGet]
        [Route("GetCouponByCode/{code}")]
        public ResponseDTO GetCouponByCode(string code)
        {
            try
            {
                var coupon = _db.Coupons.First(a => a.CouponCode.ToLower() == code.ToLower());
                response.Result = _mapper.Map<CouponDTO>(coupon);
            }
            catch (Exception e)
            {
                response.Result = e;
                response.Message = e.Message;
                response.Success = false;
            }
            return response;
        }

        [HttpPost]
        [Route("CreateCoupon")]
        public ResponseDTO CreateCoupon([FromBody] CouponDTO couponDTO)
        {
            try
            {
                var coupon = _mapper.Map<Coupon>(couponDTO);
                coupon.IsActive = true;
                coupon.CreatedBy = 1;
                coupon.UpdatedBy = 1;
                coupon.CreatedDate = DateTime.Now;
                coupon.UpdatedDate = DateTime.Now;
                _db.Coupons.Add(coupon);
                _db.SaveChanges();
                response.Result = _mapper.Map<CouponDTO>(coupon);
            }
            catch (Exception e)
            {
                response.Result = e;
                response.Message = e.Message;
                response.Success = false;
            }
            return response;
        }

        [HttpPut]
        [Route("UpdateCoupon")]
        public ResponseDTO UpdateCoupon([FromBody] CouponDTO couponDTO)
        {
            try
            {
                var coupon = _mapper.Map<Coupon>(couponDTO);
                coupon.IsActive = true;
                coupon.UpdatedBy = 1;
                coupon.UpdatedDate = DateTime.Now;
                _db.Coupons.Update(coupon);
                _db.SaveChanges();
                response.Result = _mapper.Map<CouponDTO>(coupon);
            }
            catch (Exception e)
            {
                response.Result = e;
                response.Message = e.Message;
                response.Success = false;
            }
            return response;
        }

        [HttpPut]
        [Route("DeleteCoupon/{id:int}")]
        public ResponseDTO DeleteCoupon(int id)
        {
            try
            {
                var coupon = _db.Coupons.FirstOrDefault(a => a.CouponID == id);
                coupon.IsActive = !coupon.IsActive;
                coupon.UpdatedBy = 1;
                coupon.UpdatedDate = DateTime.Now;
                _db.Coupons.Update(coupon);
                _db.SaveChanges();
                response.Message = "Deleted Successfully!";
            }
            catch (Exception e)
            {
                response.Result = e;
                response.Message = e.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
