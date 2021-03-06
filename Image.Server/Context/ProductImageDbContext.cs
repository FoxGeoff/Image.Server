﻿using Image.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace Image.Server.Context
{
    public class ProductImageDbContext : DbContext
    {
        public ProductImageDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Hero> Heroes { get; set; }
    }
}
