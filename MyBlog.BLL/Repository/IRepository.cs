using MyBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BLL.Repository
{
    public interface IRepository<T> where T:BaseEntity
    {
        IEnumerable<T> GetAll();

        void Insert(T entity);
        void Remove(T entity);
        void Update(T entity);
        T GetById(int id);

        List<T> GetAll(Expression<Func<T,bool>> filter);
        string SaveChanges();

       
          
    }
}
