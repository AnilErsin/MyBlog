using Microsoft.AspNetCore.Mvc;
using MyBlog.BLL.Services;
using System.Linq;

namespace MyBlog.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IBlogService blogService;
        private readonly ICategoryService categoryService;

        public HomeController(IBlogService blogService,ICategoryService categoryService)
        {
            this.blogService = blogService;
            this.categoryService = categoryService;
        }

     

        public IActionResult Index()
        {
            TempData["Title"] = "Anasayfa";
            ViewBag.BlogSayisi = blogService.GetAllBlog().Count();
            ViewBag.KategoriSayisi = categoryService.GetAllCategories().Count();
            return View();
        }
    }
}
