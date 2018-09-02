using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Data;
using Trlifaj.Choirify.Database.Interfaces;
using Trlifaj.Choirify.Models;

namespace Trlifaj.Choirify.Database.MySQL
{
    public class NewsMapper : GenericMapper<News, int>, INewsMapper
    {
        public NewsMapper(ChoirDbContext context) : base(context)
        {

        }

        public override void Delete(News entity)
        {
            entity.IsDeleted = true;
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
