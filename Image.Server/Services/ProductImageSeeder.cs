using Image.Server.Context;
using Image.Server.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Image.Server.Services
{
    public class ProductImageSeeder
    {
        private readonly ProductImageDbContext _context;
        private readonly IHostingEnvironment _hosting;

        public ProductImageSeeder(ProductImageDbContext context, IHostingEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        public void Seed()
        {
            if (!_context.Heroes.Any())
            {
                Hero[] heroes =
                {
                    new Hero { Id=1, Name="Windstorm"},
                    new Hero { Id=2, Name="Bombasto"},
                    new Hero { Id=3, Name="Magneta"},
                    new Hero { Id=4, Name="Tornado"}
                };
                _context.Heroes.AddRange(heroes);
                _context.SaveChanges();
            }

            if (!_context.ProductImages.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/product_images_mod.json");
                var json = File.ReadAllText(filepath);
                var productImages = JsonConvert.DeserializeObject<IEnumerable<ProductImage>>(json);
                productImages = ConvertImagesBase64ToBinary(productImages);
                _context.ProductImages.AddRange(productImages);
                _context.SaveChanges();
            }

            if (!_context.Products.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/product_mod.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _context.Products.AddRange(products);
                _context.SaveChanges();
            }
        }


        /* The seed file is .Json this method ensures
         * that the string representation is stored in 
         * the database as a binary image and not text
         * to match the legacy data
         */

        public IEnumerable<ProductImage> ConvertImagesBase64ToBinary(IEnumerable<ProductImage> productImages)
        {
            foreach (var product in productImages)
            {
                var imageString = Convert.ToBase64String(product.ImageFull);
                var imageArray = Convert.FromBase64String(imageString);
                product.ImageFull = imageArray;

                var imageStringThb = Convert.ToBase64String(product.ImageThumb);
                var imageArrayThb = Convert.FromBase64String(imageString);
                product.ImageThumb = imageArray;
            }

            return productImages;
        }

        public string ReadImageFile(string path)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(path);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            return base64ImageRepresentation;
        }
    }
}
