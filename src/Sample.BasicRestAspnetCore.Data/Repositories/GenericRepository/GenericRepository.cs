using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sample.BasicRestAspnetCore.Data.Context;
using Sample.BasicRestAspnetCore.EntitiesDomain.Base;

namespace Sample.BasicRestAspnetCore.Data.Repositories.GenericRepository
{
    public class GenericRepository<T> : IRepository<T>
        where T: BaseEntity
    {

        private readonly MySqlContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public T Create(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

            return entity;
        }

        public void Delete(object id)
        {
            try
            {
                var rsData = FindById(id);
                if (rsData != null)
                {
                    _dbSet.Remove(rsData);
                    _context.SaveChanges();
                }
               

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public System.Collections.Generic.List<T> FindAll()
        {
           return _dbSet.ToList();
        }

        public T FindById(object id)
        {
             return _dbSet.Find(id);
        }

        public T Update(T entity)
        {
            try
            {
                var rsData = FindById(entity.Id);
                if (rsData != null)
                {
                    _context.Entry(rsData).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                }
                else
                {
                    return null;
                }

            }
            catch (System.Exception ex)
            {

                throw ex;
            }


            return entity;

        }
    }
}