using Microsoft.EntityFrameworkCore;
using Products.Service.Interfaces;
using Products.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Service.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppFile> Files { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
