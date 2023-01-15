using Microsoft.EntityFrameworkCore;
using MyBlog.Dal.Context;
using MyBlog.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BLL.Repository
{
    public class BlogRepo: BaseRepository<Blog>,IBlogRepo
    {
        private readonly ProjectContext context;

        public BlogRepo(ProjectContext context): base(context)
        {
            this.context = context;
        }

        public List<Blog> GetListWithCategory()
        {
            
            
                return context.Blogs.Include(x => x.Category).ToList();
            
        }
    }
}
