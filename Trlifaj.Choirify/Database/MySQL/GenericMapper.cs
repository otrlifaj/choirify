using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Trlifaj.Choirify.Data;
using Trlifaj.Choirify.Database.Interfaces;

namespace Trlifaj.Choirify.Database.MySQL
{
    public abstract class GenericMapper<Entity, IdType> : IDataMapper<Entity, IdType>  where Entity : class
    {
        protected ChoirDbContext Context { get; set; }

        public GenericMapper(ChoirDbContext context)
        {
            Context = context;
        }

        public virtual Entity Find(IdType id)
        {
            return Context.Set<Entity>().Find(id);
        }

        public virtual IQueryable<Entity> FindAll()
        {
            IQueryable<Entity> query = Context.Set<Entity>();
            return query;
        }

        public virtual IQueryable<Entity> FindBy(Expression<Func<Entity, bool>> predicate)
        {
            IQueryable<Entity> query = Context.Set<Entity>().Where(predicate);
            return query;
        }

        public virtual Entity Create(Entity entity)
        {
            var result = Context.Set<Entity>().Add(entity);
            Context.SaveChanges();
            return result.Entity;
        }

        public virtual void Delete(Entity entity)
        {
            Context.Set<Entity>().Remove(entity);
            Context.SaveChanges();
        }

        public virtual void Update(Entity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }
    }
}
