using Microsoft.EntityFrameworkCore;
using MyBlog.Dal.Context;
using MyBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BLL.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private  ProjectContext _context;
        private DbSet<T> _entites;
        public BaseRepository(ProjectContext context)
        {
            _context = context;
            _entites = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entites.AsEnumerable();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return _entites.Where(filter).ToList();
        }

        public T GetById(int id)
        {
            return _entites.Find(id);
        }
      
        public void Insert(T entity)
        {
            //await _context.Set<T>().AddAsync(entity);
            //await _context.SaveChangesAsync();
            if (entity != null)
            {
                _entites.Add(entity);
                SaveChanges();

            }

        }

        public void Remove(T entity)
        {
            if (entity !=null)
            {
                _entites.Remove(entity);
                SaveChanges();
            }
        }

        public string SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                return "İşlem Başarıyla Gerçekleşti";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public void Update(T entity)
        {
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
                SaveChanges();
            }
        }
    }
}
