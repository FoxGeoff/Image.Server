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

        public ImageRepository(ProductImageDbContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public void AddBook(Product ProductToAdd)
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

        public Task<IEnumerable<ProductImage>> GetProductImagesAsync(IEnumerable<int> bookIds)
        {
            throw new NotImplementedException();
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
