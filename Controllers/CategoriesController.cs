using KeyboArt.Data.Services;
using KeyboArt.Data.Static;
using KeyboArt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KeyboArt.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _service;
        public CategoriesController(ICategoriesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync();
            return View(result);
        }

        //Get: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,ImageURL,CategoryName")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            await _service.AddAsync(category);
            return RedirectToAction(nameof(Index));
        }

        //Get: Products/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var categoryDetails = await _service.GetByIdAsync(id);
            if (categoryDetails == null)
            {
                return View("NotFound");
            }
            return View(categoryDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageURL,CategoryName")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            await _service.UpdateAsync(id, category);
            return RedirectToAction(nameof(Index));
        }

        //Get: Products/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var categoryDetails = await _service.GetByIdAsync(id);
            if (categoryDetails == null)
            {
                return View("NotFound");
            }
            return View(categoryDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryDetails = await _service.GetByIdAsync(id);
            if (categoryDetails == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
