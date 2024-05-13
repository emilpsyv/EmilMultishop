using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MULTISHOP.DAL;
using MULTISHOP.Extention;
using MULTISHOP.Models;
using MULTISHOP.ViewModels.Categories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MULTISHOP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(ContextEMultishop _context, IWebHostEnvironment _env) : Controller
    {
        public async Task< IActionResult> Index()
        {
            var data = await _context.Categories.Where(x => !x.IsDeleted).Select(s => new GetCategoryVm
            {
                Name = s.Name,
                Id = s.Id,
                ImgUrl = s.ImgUrl,
            }
            ).ToListAsync();

            return View(data);
        }
        [HttpGet]
        public async Task <IActionResult> Create()
        {
                return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create (CreateCategoryVM data)
        {

            if (!data.ImageFile.IsValidType("image"))
                ModelState.AddModelError("ImageFile", "Fayl sekil olmalidir");
            if (!data.ImageFile.IsValidLength(200))
                ModelState.AddModelError("ImageFile", "Filenin olcusu 200kbdan cox olmamalidir");
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            string fileName = await data.ImageFile.SaveFileAsync(Path.Combine(_env.WebRootPath, "imgs", "products"));

            await _context.Categories.AddAsync(new Models.Category
            {
                
                ImgUrl = Path.Combine("imgs", "products", fileName),
                IsDeleted = false,
                Name = data.Name,             
                DateTime = DateTime.Now

            }
            );
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound();
            UpdateCategoryVM categoryVM = new UpdateCategoryVM { Name = category.Name };
            return View(categoryVM);
        }
        [HttpPost]

        public async Task<IActionResult> Update(int? id, GetCategoryVm categoryVM)
        {
            if (id == null || id < 1) return BadRequest();
            Category exisdet = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (exisdet == null) return NotFound();
            exisdet.Name = categoryVM.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            var delS = await _context.Categories.FindAsync(id);
            if (delS == null) return BadRequest();
            _context.Categories.Remove(delS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
