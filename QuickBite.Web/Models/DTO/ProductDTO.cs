﻿using System.ComponentModel.DataAnnotations;
using QuickBite.Web.Utility;
namespace QuickBite.Web.Models.DTO;

public class ProductDTO
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string? ImageUrl { get; set; }
    public string? ImageLocalPath { get; set; }
    [Range(1, 100)]
    public int Count { get; set; } = 1;
    [MaxFileSize(1)]
    [AllowedExtensions(new string[] { ".jpg", ".png" })]
    public IFormFile? Image { get; set; }
}
