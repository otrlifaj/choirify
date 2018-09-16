using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Services
{
    public static class Roles
    {
        public const string Admin = "Admin";

        public const string Singer = "Singer";

        public const string Choirmaster = "Choirmaster";

        public const string VoiceLeader = "VoiceLeader";

        public const string DresscodeLeader = "DressCodeLeader";

        public const string Chairman = "Chairman";

        public const string ViceChairman = "ViceChairman";

        public const string MusicDistributor = "MusicDistributor";

        public const string Manager = "Manager";

        public static class Admins
        {
            public const string EventAdmins = "Admin,Chairman,ViceChairman";
            public const string SongAdmins = "Admin,Chairman,ViceChairman,MusicDistributor";
            public const string UserAdmins = "Admin,Chairman,ViceChairman";
            public const string SingerAdmins = "Admin,Chairman,ViceChairman";
            public const string RehearsalAdmins = "Admin,Chairman,ViceChairman";

        }
    }
}
