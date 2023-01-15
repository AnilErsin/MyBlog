using MyBlog.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BLL.Services
{
    public interface IBlogService
    {
        IEnumerable<Blog> GetAllBlog();

        void CreateBlog(Blog blog);
        void RemoveBlog(Blog blog);
        void UpdateBlog(Blog blog);
        Blog BlogGetById(int id);

        List<Blog> GetBlogByID(int id);
        List<Blog> Last3Blog();
        List<Blog> Last1Blog();

        List<Blog> GetBlogListWithCategory();
    }
}
