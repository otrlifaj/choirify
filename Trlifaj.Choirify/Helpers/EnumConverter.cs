using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.Helpers
{
    public static class EnumConverter
    {
        internal static string GetEventTypeNameString(EventType eventType)
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

        internal static string GetSheetTypeNameString(SheetType sheetType)
        {
            string result = null;
            switch (sheetType)
            {
                case SheetType.Unified:
                    result = "Jednotné";
                    break;
                case SheetType.MenWomenSeparated:
                    result = "Mužské a ženské";
                    break;
                case SheetType.VoicesSeparated:
                    result = "Rozdělené po hlasech";
                    break;
            }
            return result;
        }

        internal static string GetSheetInfoTypeNameString(SheetInfoType sheetInfoType)
        {
            string result = null;
            switch (sheetInfoType)
            {
                case SheetInfoType.NoCopy:
                    result = "Nemá noty";
                    break;
                case SheetInfoType.HasCopy:
                    result = "Má noty";
                    break;
                case SheetInfoType.Ordered:
                    result = "Objednáno";
                    break;
            }
            return result;
        }

        internal static string GetDressOrderTypeNameString(DressOrderType dressOrderType)
        {
            string result = null;
            switch (dressOrderType)
            {
                case DressOrderType.Own:
                    result = "Vlastní";
                    break;
                case DressOrderType.Borrowed:
                    result = "Už půjčené";
                    break;
                case DressOrderType.XS:
                    result = "XS";
                    break;
                case DressOrderType.S:
                    result = "S";
                    break;
                case DressOrderType.M:
                    result = "M";
                    break;
                case DressOrderType.L:
                    result = "L";
                    break;
            }
            return result;
        }
    }
}
