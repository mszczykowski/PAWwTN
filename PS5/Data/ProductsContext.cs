using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PS5.Models;
using Microsoft.EntityFrameworkCore;

namespace PS5.Data
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Product { get; set; }
    }
}
