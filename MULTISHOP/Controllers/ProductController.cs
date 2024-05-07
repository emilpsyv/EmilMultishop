using Microsoft.AspNetCore.Mvc;

namespace MULTISHOP.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail()
        {
            return View();
        }
    }
}
