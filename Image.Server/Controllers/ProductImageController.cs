using Image.Server.Context;
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
        public async Task<ActionResult> GetProductImagesAsync()
        {

            var productImageEntities = await _imageRepository.GetProductImagesAsync();

            return Ok(productImageEntities);
        }
    }
}
