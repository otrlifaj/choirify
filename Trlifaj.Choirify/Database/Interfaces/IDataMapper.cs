using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Database.Interfaces
{
    public interface IDataMapper<Entity> where Entity : class
    {
        Entity Find(int id);
        IQueryable<Entity> FindAll();
        IQueryable<Entity> FindBy(Expression<Func<Entity, bool>> predicate);
        Entity Create(Entity entity);
        void Update(Entity entity);
        void Delete(Entity entity);
    }
}
