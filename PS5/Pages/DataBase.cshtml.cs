using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS5.Services;
using PS5.Models;

namespace PS5.Pages
{
    public class DataBaseModel : PageModel
    {
        public DBProductService ProductService;
        public IEnumerable<Product> Products { get; private set; }

        public DataBaseModel(DBProductService productService)
        {
            ProductService = productService;
        }

        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}
