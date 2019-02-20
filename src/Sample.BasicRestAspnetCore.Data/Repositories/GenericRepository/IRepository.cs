using System.Collections.Generic;
using Sample.BasicRestAspnetCore.EntitiesDomain.Base;

namespace Sample.BasicRestAspnetCore.Data.Repositories.GenericRepository
{
    public interface IRepository<T> 
        where T : BaseEntity
    {
        T Create(T entity);
        T FindById(object id);
        List<T> FindAll();
        T Update(T entity);
        void Delete(object id);
    }
}