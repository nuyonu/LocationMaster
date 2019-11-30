using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using LocationMaster_API.Models.Repository.IRepository;

namespace LocationMaster_API.Models.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(LocationMasterContext context)
        {
            _entities = context.Set<T>();
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
        }

        private readonly DbSet<T> _entities;
    }
}