﻿using HRMS.Core.DataAccess.Abstract;
using HRMS.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRMS.DataAccess.Repositories
{
    public class EfEntityRepositoryBase<TEntity, TContext>(TContext context) : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        protected readonly TContext _context = context;

        public void Add(TEntity entity)
        {

            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public bool Any(Expression<Func<TEntity, bool>> expression)
        {

            return _context.Set<TEntity>().Any(expression);
        }

        public int Count(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Count(expression);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().FirstOrDefault(expression);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? expression = null)
        {
            return expression == null ?
                    _context.Set<TEntity>().ToList() :
                    _context.Set<TEntity>().Where(expression).ToList();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
