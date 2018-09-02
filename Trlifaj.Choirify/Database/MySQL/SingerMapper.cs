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
    public class SingerMapper : GenericMapper<Singer, int>, ISingerMapper
    {
        public SingerMapper(ChoirDbContext context) : base(context)
        {

        }

        public override void Delete(Singer entity)
        {
            entity.IsDeleted = true;
            entity.IsActive = false;
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
