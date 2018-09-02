using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;
using Trlifaj.Choirify.Services;

namespace Trlifaj.Choirify.ViewModels
{
    public class CountriesAndVoiceGroupsViewModel
    {
        private static IRoleManager roleManager { get; set; } = new RoleManager();

        public readonly IEnumerable<SelectListItem> Countries = new List<SelectListItem> {
            new SelectListItem
            {
                Text = "Česká republika",
                Value = "Česká republika",
                Selected =true
            },
            new SelectListItem
            {
                Text = "Slovensko",
                Value = "Slovensko"
            }
        };

        public readonly IEnumerable<SelectListItem> VoiceGroups =
            Enum.GetValues(typeof(VoiceGroup))
                .Cast<VoiceGroup>()
                .Select(vg =>
            new SelectListItem
            {
                Text = vg.ToString(),
                Value = ((int)vg).ToString()
            });

        private SelectListItem ConvertRoleToSelectListItem(ChoirRole role)
        {
            return new SelectListItem
            {
                Text = role.DisplayName,
                Value = role.Value
            };
        }

        public readonly IEnumerable<SelectListItem> Roles;

        public CountriesAndVoiceGroupsViewModel()
        {
            Roles = roleManager.ChoirRoles.Select(r => ConvertRoleToSelectListItem(r));
        }
        


    }
}
