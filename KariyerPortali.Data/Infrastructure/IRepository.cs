﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        void Add(T entity);
        // Marks an entity as modified
        void Update(T entity);
        // Marks an entity to be removed
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        // Get an entity by int id
        T GetById(int id, params string[] Navigations);
        // Get an entity using delegate
        T Get(Expression<Func<T, bool>> where, params string[] Navigations);
        // Gets all entities of type T
        IEnumerable<T> GetAll(params string[] Navigations);
        // Gets entities using delegate
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where, params string[] Navigations);
    }
}
