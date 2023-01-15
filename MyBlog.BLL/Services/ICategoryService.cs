using MyBlog.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BLL.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();

        void CreateCategory(Category category);
        void RemoveCategory(Category category);
        void UpdateCategory(Category category);
        Category CategoryGetById(int id);


    }
}
