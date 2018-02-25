using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Services
{
    public class EmailSettings
    {
        public String PrimaryDomain { get; set; }

        public int PrimaryPort { get; set; }

        public String DisplayName { get; set; }

        public String UsernameEmail { get; set; }

        public String UsernamePassword { get; set; }

        public String Security { get; set; }
    }
}
