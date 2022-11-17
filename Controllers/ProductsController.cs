using KeyboArt.Data.Services;
using KeyboArt.Data.Static;
using KeyboArt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace KeyboArt.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;
        public ProductsController(IProductsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync(n => n.Category);
            return View(result);
        }

        //Get: Products/Create
        public async Task<IActionResult> Create()
        {
            var productDropdownData = await _service.GetProductDropdownVM();
            ViewBag.CategoryId = new SelectList(productDropdownData.Categories, "Id", "CategoryName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Quantity,ImageURL,CategoryId")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }

        //Get: Products/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var productDropdownData = await _service.GetProductDropdownVM();
            ViewBag.CategoryId = new SelectList(productDropdownData.Categories, "Id", "CategoryName");

            var productDetails = await _service.GetByIdAsync(id);
            if(productDetails == null)
            {
                return View("NotFound");
            }
            return View(productDetails);
        }

        //Get: Products/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var productDropdownData = await _service.GetProductDropdownVM();
            ViewBag.CategoryId = new SelectList(productDropdownData.Categories, "Id", "CategoryName");

            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null)
            {
                return View("NotFound");
            }
            return View(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Quantity,ImageURL,CategoryId")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.UpdateAsync(id, product);
            return RedirectToAction(nameof(Index));
        }

        //Get: Products/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var productDropdownData = await _service.GetProductDropdownVM();
            ViewBag.CategoryId = new SelectList(productDropdownData.Categories, "Id", "CategoryName");

            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null)
            {
                return View("NotFound");
            }
            return View(productDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
