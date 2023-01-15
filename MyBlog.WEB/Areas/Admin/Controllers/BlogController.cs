using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BLL.Services;
using MyBlog.Entities.Entity;
using MyBlog.WEB.Models.ViewModel;
using System;
using System.IO;
using System.Linq;
using System.Web;

namespace MyBlog.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;
        private readonly ICategoryService categoryService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BlogController(IBlogService blogService,ICategoryService categoryService,IWebHostEnvironment webHostEnvironment)
        {
            this.blogService = blogService;
            this.categoryService = categoryService;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var blog = blogService.GetAllBlog().ToList();
            return View(blog);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = categoryService.GetAllCategories().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.ID.ToString()
            });
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddBlogImage model)
        {
            string uniqueFileName = null;

            if (model.ThumbnailImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "BlogImage");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ThumbnailImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.ThumbnailImage.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            Blog newBlog = new Blog
            {
                CreatedDate = DateTime.Now,
                CategoryID=model.CategoryID,
                BlogContent = model.BlogContent,
                BlogTitle = model.BlogTitle,
                BlogWriterName = model.BlogWriterName,
                BlogThumbnailImage = uniqueFileName
                

            };

            blogService.CreateBlog(newBlog);

            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var Deleteblog = blogService.BlogGetById(id);
            blogService.RemoveBlog(Deleteblog);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var blog = blogService.BlogGetById(id);
            ViewBag.Categories = categoryService.GetAllCategories()
              .Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
              {
                  Text = x.CategoryName,
                  Value = x.ID.ToString()
              });
            return View(blog);

            
        }

        [HttpPost]
        public IActionResult Update(Blog blog)
        {
           
             blog.CreatedDate = DateTime.Now;

             blogService.UpdateBlog(blog);

            return RedirectToAction("Index");
        }
    }
}
