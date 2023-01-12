using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // Generic constrait  
    // Class : Indicates that it is a reference type.
    //IEntity : It can be an IEntity or an object that implements IEntity
    //new : To prevent the use of IEntity
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // Generic Repository Design Pattern
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
