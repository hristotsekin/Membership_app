using Membership_App.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Membership_App.Models
{
    public interface IRepository<TEntity> where TEntity : class
    {

        void Add(TEntity entity);
        
        void Remove(TEntity entity);
        
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    }
}
