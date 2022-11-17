using KeyboArt.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KeyboArt.Controllers
{
    public class ProductsFilterController : Controller
    {
        private readonly AppDbContext _context;
        public ProductsFilterController(AppDbContext context)
        {
            _context = context;  
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Products.ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _context.Products.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filterProduct = allProducts.Where(n => n.Name.ToUpper().Contains(searchString.ToUpper()) || n.Description.ToUpper().Contains(searchString.ToUpper())).ToList();
                return View("Index", filterProduct);
            }

            return View("Index", allProducts);
        }

        public async Task<IActionResult> Keyboards()
        {
            var query = await _context.Products.Where(p => p.CategoryId == 1).ToListAsync();
            return View(query);
        }

        public async Task<IActionResult> Switches()
        {
            var query = await _context.Products.Where(p => p.CategoryId == 2).ToListAsync();
            return View(query);
        }

        public async Task<IActionResult> Cases()
        {
            var query = await _context.Products.Where(p => p.CategoryId == 3).ToListAsync();
            return View(query);
        }

        public async Task<IActionResult> Keycaps()
        {
            var query = await _context.Products.Where(p => p.CategoryId == 4).ToListAsync();
            return View(query);
        }

        public async Task<IActionResult> Plates()
        {
            var query = await _context.Products.Where(p => p.CategoryId == 5).ToListAsync();
            return View(query);
        }

        public async Task<IActionResult> Accesories()
        {
            var query = await _context.Products.Where(p => p.CategoryId == 6).ToListAsync();
            return View(query);
        }

        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (productDetails == null)
            {
                return View("Empty");
            }
            return View(productDetails);
        }
    }
}
