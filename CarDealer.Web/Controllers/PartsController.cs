﻿

namespace CarDealer.Web.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Services;
    using CarDealer.Web.Models.Parts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class PartsController: Controller
    {
        private const int pageSize = 25;

        private readonly IPartService parts;
        private readonly ISupplierService suppliers;

        public PartsController(IPartService parts, ISupplierService suppliers)
        {
            this.parts = parts;
            this.suppliers = suppliers;
        }

        public IActionResult Create() => View(new PartFormModel
        {
            Suppliers = this.GetSupplierListItems();
        });

        [HttpPost]
        public IActionResult Create(PartFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Suppliers = this.GetSupplierListItems();
                return View(model);
            }

            this.parts.Create(model.Name, model.Price, model.Quantity, model.SupplierId);

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult All(int page=1)
        =>
         View(new PartPageListingModel
         {
             Parts = this.parts.All(page, pageSize),
             CurrentPage = page,
             TotalPages = (int)Math.Ceiling(this.parts.TotalPages() / (double)pageSize)
         });

        private IEnumerable <SelectListItem> GetSupplierListItems()
        {
            return this.suppliers.All().Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString()

            });

        }
    }
}
