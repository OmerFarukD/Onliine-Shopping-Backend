using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Core.Entity.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityDal<TEntity,TContext> :IEntityDal<TEntity>
    where TEntity:class,IEntity,new()
    where TContext:DbContext,new()
    {
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context=new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context=new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context=new TContext())
            {
                var DeletedEntity = context.Remove(entity);
                DeletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Add(TEntity entity)
        {
            using (var context=new TContext())
            {
                var AddedEntity = context.Add(entity);
                AddedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context=new TContext())
            {
                var UpdatedEntity = context.Update(entity);
                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
