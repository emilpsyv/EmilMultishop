using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MULTISHOP.DAL;
using MULTISHOP.Models;
using MULTISHOP.ViewModels.Categories;
using MULTISHOP.ViewModels.HomeVM;
using MULTISHOP.ViewModels.Sliders;

namespace MULTISHOP.Controllers
{
    public class HomeController(ContextEMultishop _context) : Controller
    {
        
            public async Task<IActionResult> Index()
            {
                var sliders = await _context.Sliders
                    .Select(x => new GetSliderVM
                    {
                        Title = x.Title,
                        Subtitle = x.Subtitle,
                        ImgUrl = x.ImgAdress
                    })
                    .ToListAsync();

                var categories = await _context.Categories
                    .Select(x => new GetCategoryVm { Name = x.Name ,ImgUrl=x.ImgUrl})
                    .ToListAsync();

                SendVM vm = new SendVM
                {
                    GetCategoryVMs = categories,
                    GetSliderVMs = sliders
                };

                return View(vm);
            }
        

        public async Task<IActionResult> Contact()
        {
            return View();
        }

    }
}
