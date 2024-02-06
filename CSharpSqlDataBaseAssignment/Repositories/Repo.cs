using CSharpSqlDataBaseAssignment.Contexts;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSqlDataBaseAssignment.Repositories
{
    internal class Repo<TEntity> where TEntity : class
    {
        private readonly DataContext _context;

        public Repo(DataContext context)
        {
            _context = context;
        }


        public virtual TEntity Create(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in Create: {ex.Message}");
                return null!;
            }
            
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in GetAll: {ex.Message}");
                return null!;
            }
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = _context.Set<TEntity>().FirstOrDefault(expression);
                return entity!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in Get: {ex.Message}");
                return null!;
            }
        }

        public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
        {
            try
            {
                var entityToUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
                _context.Entry(entityToUpdate!).CurrentValues.SetValues(entity);
                _context.SaveChanges();
                return entityToUpdate!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in Update: {ex.Message}");
            }
            
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = _context.Set<TEntity>().FirstOrDefault(expression);
                _context.Remove(entity!);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in Delete: {ex.Message}");
            }
        }

    }
}
