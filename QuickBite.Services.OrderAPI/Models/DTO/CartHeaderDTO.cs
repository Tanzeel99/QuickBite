﻿namespace QuickBite.Services.OrderAPI.Models.DTO
{
    public class CartHeaderDTO
    {
        public int CartHeaderId { get; set; }
        public string? UserId { get; set; }
        public string? CouponCode { get; set; }
        public double Discount { get; set; }
        public double CartTotal { get; set; }


        public string? Name { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
    }
}
