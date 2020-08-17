using Membership_App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Membership_App.Models
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext _context = null;

        public UnitOfWork()
        {
            _context = new ApplicationDbContext();

        }

        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public IRepository<T> Repository<T>() where T : class
        {

            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T>;
            }

            IRepository<T> repo = new GenericRepository<T>(_context);
            repositories.Add(typeof(T), repo);

            return repo;
        }
        

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


        

        
    }
}