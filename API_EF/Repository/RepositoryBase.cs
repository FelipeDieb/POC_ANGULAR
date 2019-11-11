using PocAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocAPI.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected DatabaseContext _dbContext;

        public RepositoryBase() { }

        public RepositoryBase(DatabaseContext dbContext) : this()
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public virtual IEnumerable<T> All()
        {
            try
            {
                return _dbContext.Set<T>().AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(long id)
        {
            try
            {
                var entity = Get(id);
                if (entity != null)
                {
                    _dbContext.Set<T>().Remove(entity);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T Get(long id)
        {
            try
            {
                var entity = _dbContext.Set<T>().Find(id);
                return entity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update(long id, T entity)
        {
            try
            {
                if (Get(id) != null)
                {
                    _dbContext.Set<T>().Update(entity);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
