

namespace CarDealer.Web.Models.Cars
{
    using CarDealer.Services.Models.Parts;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarFormModel
    {
        public string Make { get; set; }
        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Display(Name ="Odometer")]
        [Range(0, long.MaxValue,ErrorMessage ="Travelled distance can not be more than 1 000 000 000 km and must be a positive number")]
        public long Distance { get; set; }

        public IEnumerable<int> SelectedParts { get; set; }

        [Display(Name ="Parts")]
        public IEnumerable<SelectListItem> AllParts { get; set; }
    }
}
