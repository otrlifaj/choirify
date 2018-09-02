using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Trlifaj.Choirify.Data;
using Trlifaj.Choirify.Database.Interfaces;
using Trlifaj.Choirify.Models;

namespace Trlifaj.Choirify.Database.MySQL
{
    public class UserMapper : GenericMapper<ApplicationUser, string>, IUserMapper
    {
        public UserMapper(ChoirDbContext context) : base(context)
        {

        }

        public override IQueryable<ApplicationUser> FindAll()
        {
            IQueryable<ApplicationUser> query = Context.Users.Include(u => u.Singer);
            return query;
        }

        public override IQueryable<ApplicationUser> FindBy(Expression<Func<ApplicationUser, bool>> predicate)
        {
            IQueryable<ApplicationUser> query = Context.Users.Include(u => u.Singer).Where(predicate);
            return query;
        }

        public override ApplicationUser Find(string id)
        {
            return Context.Users.Include(u => u.Singer).FirstOrDefault(u => u.Id == id);
        }
    }
}
