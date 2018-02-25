using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Data;
using Trlifaj.Choirify.Database.Interfaces;
using Trlifaj.Choirify.Models;

namespace Trlifaj.Choirify.Database.MySQL
{
    public class SongMapper : GenericMapper<Song, int>, ISongMapper
    {
        public SongMapper(ChoirDbContext context) : base(context)
        {

        }
    }
}
