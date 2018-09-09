using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Helpers;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.ViewModels
{
    public class EventTypesViewModel
    {
        public readonly IEnumerable<SelectListItem> EventTypes =
            Enum.GetValues(typeof(EventType))
                .Cast<EventType>()
                .Select(et =>
                    new SelectListItem
                    {
                        Text = EnumConverter.GetEventTypeNameString(et),
                        Value = ((int)et).ToString()
                    });
    }
}
