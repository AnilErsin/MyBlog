using MyBlog.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BLL.Repository
{
    public interface IBlogRepo:IRepository<Blog>
    {
        List<Blog> GetListWithCategory();
    }
}
