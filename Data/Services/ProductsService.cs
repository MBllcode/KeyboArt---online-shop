using KeyboArt.Data.Base;
using KeyboArt.Data.ViewModels;
using KeyboArt.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyboArt.Data.Services
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ProductDropdownVM> GetProductDropdownVM()
        {
            var dropdown = new ProductDropdownVM()
            {
                Categories = await _context.Categories.OrderBy(n => n.CategoryName).ToListAsync()
            };

            return dropdown;
        }
    }
}
