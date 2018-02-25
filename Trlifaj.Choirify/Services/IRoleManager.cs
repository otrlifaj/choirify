using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Services
{
    public interface IRoleManager
    {
        List<string> Roles { get; }
        string Admin { get; }
        string User { get; }
        string Singer { get; }
        string Choirmaster { get; }
        string VoiceLeader { get; }
        string DresscodeLeader { get; }
        string Chairman { get; }
        string ViceChairman { get; }
        string MusicDistributor { get; }
        string Manager { get; }
    }
}
