using Membership_App.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace Membership_App.Models
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private DbContext Context;

        public GenericRepository(DbContext context)
        {
            Context = context;
        }


        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public T Get(int id)
        {

            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>()
                .Where(predicate);
        }
    }
}