using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MULTISHOP.DAL;
using MULTISHOP.Extention;
using MULTISHOP.Models;
using MULTISHOP.ViewModels.Sliders;

namespace MULTISHOP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController(ContextEMultishop _context,IWebHostEnvironment _env) : Controller
    {
        

        // GET: Admin/Slider
        public async Task<IActionResult> Index()
        {
            var data = await _context.Sliders.Select(s => new GetSliderAdminVM
            {
                id=s.Id,
                Title = s.Title,
                Subtitle = s.Subtitle,
                CreatedTime = s.CreatedTime,
                ImgUrl =s.ImgAdress,
                IsDeleted = s.IsDeleted,
                UpdatedTime = s.UpdatedTime
            }
            ).ToListAsync();
            return View(data);
        }

     

        // GET: Admin/Slider/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
       
        public async Task<IActionResult> Create(CreateSliderVM data)
        {
            if (!data.ImageFile.IsValidType("image"))
                ModelState.AddModelError("ImageFile", "Fayl sekil olmalidir");
            if (!data.ImageFile.IsValidLength(1000))
                ModelState.AddModelError("ImageFile", "Filenin olcusu 1000kbdan cox olmamalidir");
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            string FileName = await data.ImageFile.SaveFileAsync(Path.Combine(_env.WebRootPath, "imgs", "slider"));
            Slider slider = new Slider
            {
                Title = data.Title,
                Subtitle = data.Subtitle,
                ImgAdress=Path.Combine("imgs","slider",FileName),
                UpdatedTime=DateTime.Now,
                CreatedTime=DateTime.Now,
                IsDeleted=false

            };
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

                
                

        }

      
       
      
      
    }
}
