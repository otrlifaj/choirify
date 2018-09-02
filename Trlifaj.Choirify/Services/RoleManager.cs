using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Services
{
    public class RoleManager : IRoleManager
    {
        public List<string> Roles => new List<string>
        {
            Admin,
            Singer,
            Choirmaster,
            VoiceLeader,
            DresscodeLeader,
            Chairman,
            ViceChairman,
            MusicDistributor,
            Manager
        };

        public List<ChoirRole> ChoirRoles => new List<ChoirRole>
        {
            new ChoirRole{ DisplayName = "Administrátor", Value = Admin},
            new ChoirRole{ DisplayName = "Zpěvák", Value = Singer},
            new ChoirRole{ DisplayName = "Sbormistr", Value = Choirmaster},
            new ChoirRole{ DisplayName = "Hlasový vedoucí", Value = VoiceLeader},
            new ChoirRole{ DisplayName = "Dresscode lady", Value = DresscodeLeader},
            new ChoirRole{ DisplayName = "Předseda", Value = Chairman},
            new ChoirRole{ DisplayName = "Místopředseda", Value = ViceChairman},
            new ChoirRole{ DisplayName = "Notář", Value = MusicDistributor},
            new ChoirRole{ DisplayName = "Manažer", Value = Manager},
        };

        public string Admin => "Admin";

        public string Singer => "Singer";

        public string Choirmaster => "Choirmaster";

        public string VoiceLeader => "VoiceLeader";

        public string DresscodeLeader => "DressCodeLeader";

        public string Chairman => "Chairman";

        public string ViceChairman => "ViceChairman";

        public string MusicDistributor => "MusicDistributor";

        public string Manager => "Manager";
    }
}
