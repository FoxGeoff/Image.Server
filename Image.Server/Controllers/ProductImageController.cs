using Image.Server.Context;
using Image.Server.Filters;
using Image.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Image.Server.Controllers
{
    [Route("api/productimages")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ProductImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository ??
                throw new ArgumentNullException(nameof(imageRepository));
        }

        [HttpGet]
        [ProductImagesResultFilter]
        public async Task<ActionResult> GetProductImages()
        {

            var productImageEntities = await _imageRepository.GetProductImagesAsync();
           
            return Ok(productImageEntities);
        }

        [HttpGet]
        [Route("{id}", Name = "GetProductImage")]
        public async Task<ActionResult> GetProductImage(int Id)
        {

            var productImageEntity = await _imageRepository.GetProductImageAsync(Id);
            if (productImageEntity == null)
            {
                return NotFound();
            }
            
            return Ok(productImageEntity);
        }

    }
}
