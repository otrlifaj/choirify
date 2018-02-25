using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Data;
using Trlifaj.Choirify.Database.Interfaces;
using Trlifaj.Choirify.Models;
using Trlifaj.Choirify.Models.ManyToMany;

namespace Trlifaj.Choirify.Database.MySQL
{
    public class SheetsInfoMapper : GenericMapper<UserSong>, ISheetsInfoMapper
    {
        public SheetsInfoMapper(ChoirDbContext context) : base(context)
        {

        }
    }
}
