using Microsoft.AspNetCore.Http;
using MyBlog.Entities.Entity;

namespace MyBlog.WEB.Models.ViewModel
{
    public class AddBlogImage
    {
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogWriterName { get; set; }

        public IFormFile ThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public int CategoryID { get; set; }

        public Category category { get; set; }
    }
}
