using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    //Repository<Product>
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            //ket noi db
            _db = db;
            //_db.product == Table product
            //dbset= _db.set rut ngan cu phap
            dbSet = _db.Set<T>();

        }
        //_db.product.Add
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        //Expression<Func<T, bool>> filter = lambda expression
        // p => p.Id == id
        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            // Iqueryable tạo truy vấn nhưng ko thực thi , thực thi khi sử dụng tolist..,getfirst...

            IQueryable<T> query = dbSet;
            //sql WHERE Id = ?
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
        // tra ve Ienum
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);

            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var inclueProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(inclueProp);
                }
            }
            //select * FROM
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
