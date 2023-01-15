using Microsoft.AspNetCore.Mvc;
using MyBlog.BLL.Services;
using MyBlog.Entities.Entity;
using System;
using System.Collections.Generic;

namespace MyBlog.WEB.ViewComponents
{
    public class BlogLast1Post:ViewComponent
    {
        private readonly IBlogService blogService;

        public BlogLast1Post(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var values = blogService.Last1Blog();

            return View(values);
        }

       
    }
}
