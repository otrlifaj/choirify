using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Helpers;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.ViewModels
{
    public class SheetTypesViewModel
    {
        public readonly IEnumerable<SelectListItem> SheetTypes =
            Enum.GetValues(typeof(SheetType))
                .Cast<SheetType>()
                .Select(st =>
                    new SelectListItem
                    {
                        Text = EnumConverter.GetSheetTypeNameString(st),
                        Value = ((int)st).ToString()
                    });
    }
}
