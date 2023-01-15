using MyBlog.BLL.Repository;
using MyBlog.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Category CategoryGetById(int id)
        {
            return categoryRepository.GetById(id);
        }

        public void CreateCategory(Category category)
        {
            categoryRepository.Insert(category);
        }

        public IEnumerable<Category> GetAllCategories()
        {
           return categoryRepository.GetAll().ToList();
        }


        public void RemoveCategory(Category category)
        {
            categoryRepository.Remove(category);
        }

        public void UpdateCategory(Category category)
        {
            categoryRepository.Update(category);
        }
    }
}
