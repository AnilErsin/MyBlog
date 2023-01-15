using Microsoft.AspNetCore.Mvc;
using MyBlog.BLL.Services;
using MyBlog.Entities.Entity;
using System.Linq;

namespace MyBlog.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IBlogService blogService;

        public CategoryController(ICategoryService categoryService,IBlogService blogService)
        {
            this.categoryService = categoryService;
            this.blogService = blogService;
        }
        public IActionResult Index()
        {

            ViewBag.BlogCount = blogService.GetAllBlog().Count();

            TempData["Title"] = "Kategori";
            var categories = categoryService.GetAllCategories().ToList();

            return View(categories);

            

        }

        public IActionResult Create()
        {
            TempData["Title"] = "Yeni Kategori";
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            categoryService.CreateCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = categoryService.CategoryGetById(id);
            categoryService.RemoveCategory(category);
            return RedirectToAction("Index");

        }

        public IActionResult Update(int id)
        {
            var category = categoryService.CategoryGetById(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            categoryService.UpdateCategory(category);
            return RedirectToAction("Index");
        }

    }
}
