﻿using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using DeviceManagement_WebApp.Interface;
using DeviceManagement_WebApp.Data;
using System.Linq;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ConnectedOfficeContext _context;

        public GenericRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        internal object GetById(Guid? id)
        {
            if (id == null)
                return null;
            return _context.Set<T>().Find(id);
        }

        public void SaveChangesAsync()
        {
            this._context.SaveChangesAsync();
        }
        public void Update(T Entity)
        {
            this._context.Update(Entity);
        }
        public ConnectedOfficeContext GetContext()
        {
            return this._context;
        }

        public bool EntityExists(Guid id)
        {
            return this.GetById(id) != null;
        }
    }
}