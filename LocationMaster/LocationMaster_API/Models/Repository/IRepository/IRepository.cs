﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LocationMaster_API.Models.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}