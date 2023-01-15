using MyBlog.BLL.Repository;
using MyBlog.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BLL.Services
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<Blog> blogRepository;
        private readonly IBlogRepo blogRepo;

        public BlogService(IRepository<Blog> blogRepository , IBlogRepo blogRepo)
        {
            this.blogRepository = blogRepository;
            this.blogRepo = blogRepo;
        }
        public Blog BlogGetById(int id)
        {
            return blogRepository.GetById(id);
        }

        public void CreateBlog(Blog blog)
        {
            blogRepository.Insert(blog);
        }

        public IEnumerable<Blog> GetAllBlog()
        {
            return blogRepository.GetAll().ToList();
        }

        public List<Blog> GetBlogByID(int id)
        {
            return blogRepository.GetAll(x => x.ID == id);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return blogRepo.GetListWithCategory();
        }

        public List<Blog> Last1Blog()
        {
            return blogRepository.GetAll().Take(1).ToList();
        }

        public List<Blog> Last3Blog()
        {
            return blogRepository.GetAll().Take(3).ToList();
        }

        public void RemoveBlog(Blog blog)
        {
            blogRepository.Remove(blog);
        }

        public void UpdateBlog(Blog blog)
        {
            blogRepository.Update(blog);
        }

       
    }
}
