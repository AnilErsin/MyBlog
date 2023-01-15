using Microsoft.AspNetCore.Mvc;
using MyBlog.BLL.Repository;
using MyBlog.BLL.Services;
using MyBlog.Entities.Entity;

namespace MyBlog.WEB.ViewComponents
{
    public class BlogLast3Post: ViewComponent
    {
        private readonly IBlogService blogService;

        public BlogLast3Post(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var values = blogService.Last3Blog();

            return View(values);
        }

    }
}
