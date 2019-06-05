using AutoMapper;
using Image.Server.Filters;
using Image.Server.Models;
using Image.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Image.Server.Controllers
{
    [Route("api/productimages")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public ProductImageController(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository ??
                throw new ArgumentNullException(nameof(imageRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
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

        [HttpPost]
        [ProductImageResultFilter]
        public async Task<IActionResult> CreateProductImage([FromBody] ProductImageForCreation productImage)
        {
            var productImageEntity = _mapper.Map<Entities.ProductImage>(productImage);
            _imageRepository.AddProductImage(productImageEntity);

            await _imageRepository.SaveChangesAsync();

            //Fetch (refetch) the book from the data store to include author
            await _imageRepository.GetProductImageAsync(productImageEntity.Id);

            return CreatedAtRoute("GetProductImage",
                new { id = productImageEntity.Id },
                productImageEntity);
        }
    }
}
