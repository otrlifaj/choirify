using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Data;
using Trlifaj.Choirify.Database.Interfaces;
using Trlifaj.Choirify.Models;

namespace Trlifaj.Choirify.Database.MySQL
{
    public class EventMapper : GenericMapper<Event>, IEventMapper
    {
        public EventMapper(ChoirDbContext context) : base(context)
        {

        }
    }
}
