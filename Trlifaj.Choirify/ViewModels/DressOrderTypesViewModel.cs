using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Helpers;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.ViewModels
{
    public class DressOrderTypesViewModel
    {
        public readonly IEnumerable<SelectListItem> DressOrderTypes =
            Enum.GetValues(typeof(DressOrderType))
                .Cast<DressOrderType>()
                .Select(dot =>
                    new SelectListItem
                    {
                        Text = EnumConverter.GetDressOrderTypeNameString(dot),
                        Value = ((int)dot).ToString()
                    });

        public readonly IEnumerable<SelectListItem> SingerDressOrderTypes =
            Enum.GetValues(typeof(DressOrderType))
                .Cast<DressOrderType>()
                .Select(dot =>
                    new SelectListItem
                    {
                        Text = EnumConverter.GetSingerDressOrderTypeNameString(dot),
                        Value = ((int)dot).ToString()
                    });
    }
}
