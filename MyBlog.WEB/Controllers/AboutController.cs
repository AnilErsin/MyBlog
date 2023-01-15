using Microsoft.AspNetCore.Mvc;
using MyBlog.BLL.Services;
using System.Linq;

namespace MyBlog.WEB.Controllers
{
    public class AboutController : Controller
    {
        private readonly IBlogService blogService;

        public AboutController(IBlogService blogService)
        {
            this.blogService = blogService;
        }
        public IActionResult Index()
        {
            var List = blogService.GetAllBlog().Take(6);

            return View(List);
        }
    }
}
