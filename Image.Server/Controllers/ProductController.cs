using Image.Server.Filters;
using Image.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Image.Server.Controllers
{
    [Route("api/products")]
    [ApiController]
    [ProductsResultFilter]
    public class ProductController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ProductController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository ??
                throw new ArgumentNullException(nameof(imageRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productEntities = await _imageRepository.GetProductsAsync();

            return Ok(productEntities);
        }
    }
}
