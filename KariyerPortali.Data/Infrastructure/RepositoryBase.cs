using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties
        private KariyerPortaliEntities dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected KariyerPortaliEntities DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        #endregion

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(int id, params string[] Navigations)
        {
            foreach (string nav in Navigations)
                dbSet.Include(nav);

            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll(params string[] Navigations)
        {
            foreach (string nav in Navigations)
                dbSet.Include(nav);

            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, params string[] Navigations)
        {
            foreach (string nav in Navigations)
                dbSet.Include(nav);
            return dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where, params string[] Navigations)
        {
            foreach (string nav in Navigations)
                dbSet.Include(nav);
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        #endregion

    }
}
