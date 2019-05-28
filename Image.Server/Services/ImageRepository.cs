using Image.Server.Context;
using Image.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Image.Server.Services
{
    public class ImageRepository : IImageRepository, IDisposable
    {
        private ProductImageDbContext _context;
        private IHttpClientFactory _httpClientFactory;

        public ImageRepository(ProductImageDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
            _httpClientFactory = httpClientFactory ??
                throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public void AddProduct(Product ProductToAdd)
        {
            throw new NotImplementedException();
        }

        public void AddProductImage(ProductImage ProductImageToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductImage> GetProductImageAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductImage>> GetProductImagesAsync()
        {
            return await _context.ProductImages
                .Include(pi => pi.Products)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.ProductImage)
                .ToListAsync();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

    }
}
