using Microsoft.AspNetCore.Mvc;
using MyBlog.BLL.Services;
using System.Linq;

namespace MyBlog.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService blogService;
        private readonly ICategoryService categoryService;

        public HomeController(IBlogService blogService , ICategoryService categoryService)
        {
            this.blogService = blogService;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {

            var blog = blogService.GetBlogListWithCategory();
            return View(blog);
        }

        public IActionResult BlogDetails (int id)
        {

            ViewBag.CategoryName = categoryService.GetAllCategories().ToList();




            var values = blogService.GetBlogByID(id);

            return View(values);
        }
    }
}
