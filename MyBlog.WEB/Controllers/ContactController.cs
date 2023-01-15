using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WEB.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
