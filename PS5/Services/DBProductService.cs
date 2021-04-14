using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PS5.Data;
using PS5.Models;

namespace PS5.Services
{
    public class DBProductService
    {
        private readonly ProductsContext _context;
        public DBProductService(ProductsContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _context.Product;
        }
    }
}
