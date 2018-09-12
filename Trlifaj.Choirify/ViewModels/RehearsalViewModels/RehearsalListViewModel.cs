using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models;

namespace Trlifaj.Choirify.ViewModels.RehearsalViewModels
{
    public class RehearsalListViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Chybí datum zkoušky.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy HH:mm}")]
        [Display(Name = "Datum")]
        public DateTime Date { get; set; }

        [MaxLength(1500, ErrorMessage = "Popis může mít maximálně 1500 znaků.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Popis")]
        public string Description { get; set; }

        public RehearsalListViewModel()
        {

        }

        public RehearsalListViewModel(Rehearsal r)
        {
            Id = r.Id;
            Date = r.Date;
            Description = r.Description;
        }

        public Rehearsal ToRehearsal()
        {
            return new Rehearsal
            {
                Id = Id,
                Date = Date,
                Description = Description
            };
        }
    }
}
