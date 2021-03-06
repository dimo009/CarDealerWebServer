﻿using CarDealer.Services.Models.Suppliers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Models.Parts
{
    public class PartFormModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue,ErrorMessage ="Price must be a positive number.")]
        public int Quantity { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        public IEnumerable<SelectListItem> Suppliers { get; set; }

        public bool IsEditMode { get; set; }
    }
}
