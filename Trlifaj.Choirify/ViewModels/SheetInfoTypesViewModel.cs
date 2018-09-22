using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Helpers;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.ViewModels
{
    public class SheetInfoTypesViewModel
    {
        public readonly IEnumerable<SelectListItem> SheetInfoTypes =
            Enum.GetValues(typeof(SheetInfoType))
                .Cast<SheetInfoType>()
                .Select(st =>
                    new SelectListItem
                    {
                        Text = EnumConverter.GetSheetInfoTypeNameString(st),
                        Value = ((int)st).ToString()
                    });

        public readonly IEnumerable<SelectListItem> SingerSheetInfoTypes =
            Enum.GetValues(typeof(SheetInfoType))
                .Cast<SheetInfoType>()
                .Select(st =>
                    new SelectListItem
                    {
                        Text = EnumConverter.GetSingerSheetInfoTypeNameString(st),
                        Value = ((int)st).ToString()
                    });

    }
}
