using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBite.Services.ProductAPI.Data;
using QuickBite.Services.ProductAPI.Models;
using QuickBite.Services.ProductAPI.Models.DTO;

namespace QuickBite.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDBContext _db;
        private ResponseDTO response;
        private IMapper _mapper;
        public ProductController(ProductDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            response = new ResponseDTO();
        }

        [HttpGet]
        [Route("GetAllProduct")]
        public ResponseDTO GetAll()
        {
            try
            {
                IEnumerable<Product> objList = _db.Products.ToList();
                response.Result = _mapper.Map<IEnumerable<ProductDTO>>(objList);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("GetProductById/{id:int}")]
        public ResponseDTO GetProduct(int id)
        {
            try
            {
                Product obj = _db.Products.First(u => u.ProductId == id);
                response.Result = _mapper.Map<ProductDTO>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        [Route("CreateProduct")]
        public ResponseDTO CreateProduct(ProductDTO productDTO)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDTO);
                _db.Products.Add(product);
                _db.SaveChanges();

                if (productDTO.Image != null)
                {
                    // Generate the file name
                    string fileName = product.ProductId + Path.GetExtension(productDTO.Image.FileName);

                    // Create the directory path
                    string imageFolder = Path.Combine("wwwroot", "ProductImages");
                    string filePath = Path.Combine(imageFolder, fileName);
                    string absoluteFilePath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

                    // Ensure the image folder exists
                    string fullImageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), imageFolder);
                    if (!Directory.Exists(fullImageFolderPath))
                    {
                        Directory.CreateDirectory(fullImageFolderPath);
                    }

                    // Delete the existing image if it exists
                    FileInfo file = new FileInfo(absoluteFilePath);
                    if (file.Exists)
                    {
                        file.Delete();
                    }

                    // Save the new image
                    using (var fileStream = new FileStream(absoluteFilePath, FileMode.Create))
                    {
                        productDTO.Image.CopyTo(fileStream);
                    }

                    // Set image URL and local path
                    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                    product.ImageUrl = $"{baseUrl}/ProductImages/{fileName}";
                    product.ImageLocalPath = filePath;
                }
                else
                {
                    product.ImageUrl = "https://placehold.co/600x400";
                }

                // Update product and save changes
                _db.Products.Update(product);
                _db.SaveChanges();

                // Map result
                response.Result = _mapper.Map<ProductDTO>(product);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }


        [HttpPut]
        //[Authorize(Roles = "ADMIN")]
        [Route("UpdateProduct")]
        public ResponseDTO UpdateProduct(ProductDTO productDTO)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDTO);

                if (productDTO.Image != null)
                {
                    if (!string.IsNullOrEmpty(product.ImageLocalPath))
                    {
                        var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), product.ImageLocalPath);
                        FileInfo file = new FileInfo(oldFilePathDirectory);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }

                    string fileName = product.ProductId + Path.GetExtension(productDTO.Image.FileName);
                    string filePath = @"wwwroot\ProductImages\" + fileName;
                    var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                    using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                    {
                        productDTO.Image.CopyTo(fileStream);
                    }
                    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                    product.ImageUrl = baseUrl + "/ProductImages/" + fileName;
                    product.ImageLocalPath = filePath;
                }


                _db.Products.Update(product);
                _db.SaveChanges();

                response.Result = _mapper.Map<ProductDTO>(product);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpDelete]
        [Route("DeleteProduct/{id:int}")]
        //[Authorize(Roles = "ADMIN")]
        public ResponseDTO Delete(int id)
        {
            try
            {
                Product obj = _db.Products.First(u => u.ProductId == id);
                if (!string.IsNullOrEmpty(obj.ImageLocalPath))
                {
                    var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), obj.ImageLocalPath);
                    FileInfo file = new FileInfo(oldFilePathDirectory);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }
                _db.Products.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
