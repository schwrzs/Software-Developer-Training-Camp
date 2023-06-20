using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Generic Const
    //Class : a ref type
    //IEntity : IEntity or an impletenting object with IEntity
    public interface IEntityRepository<T> where T: class, IEntity
    {
        List<T> GetAll(Expression<Func<T,bool>> filter =null);
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<T> GetAllByProduct(int productId);

    }
}
