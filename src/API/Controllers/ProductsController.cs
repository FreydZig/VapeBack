using API.Models;
using AutoMapper;
using DataLayer.Entities;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public ProductsController(IImageService imageService, IProductsService productsService, IMapper mapper)
        {
            _imageService = imageService;
            _productsService = productsService;
            _mapper = mapper;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateProduct([FromForm]ProductModel productModel)
        {
            try
            {
                if (productModel.MyImage.Length == 0) return BadRequest("File is empty!");

                var path = await _imageService.Create(productModel.MyImage);

                var product = new Products 
                { 
                    Name = productModel.ProductName,
                    SubtypeId = productModel.SubtypeId,
                    TypeId = productModel.TypeId,
                    Description = productModel.Description,
                    Image = path,
                    Price = productModel.Price
                };

                var answer = await _productsService.Add(product);

                return Ok(answer);
            }
            catch (ImageProcessingException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
