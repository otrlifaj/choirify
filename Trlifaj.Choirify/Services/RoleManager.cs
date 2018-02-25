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
            User,
            Singer,
            Choirmaster,
            VoiceLeader,
            DresscodeLeader,
            Chairman,
            ViceChairman,
            MusicDistributor,
            Manager
        };

        public string Admin => "Admin";

        public string User => "User";

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
