using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.Helpers
{
    public static class EnumConverter
    {
        public static string GetEventTypeNameString(EventType eventType)
        {
            string result = null;
            switch (eventType)
            {
                case EventType.Concert:
                    result = "Koncert";
                    break;
                case EventType.Tour:
                    result = "Výjezd";
                    break;
                case EventType.Workshop:
                    result = "Soustředění";
                    break;
            }
            return result;

        }
    }
}
