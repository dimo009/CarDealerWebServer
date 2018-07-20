

namespace CarDealer.Web.Controllers
{
    using System;
    using CarDealer.Services;
    using CarDealer.Web.Models.Parts;
    using Microsoft.AspNetCore.Mvc;


    public class PartsController: Controller
    {
        private const int pageSize = 25;

        private readonly IPartService parts;

        public PartsController(IPartService parts)
        {
            this.parts = parts;
        }

        public IActionResult Create() => View();

        public IActionResult All(int page=1)
        =>
         View(new PartPageListingModel
         {
             Parts = this.parts.All(page, pageSize),
             CurrentPage = page,
             TotalPages = (int)Math.Ceiling(this.parts.TotalPages() / (double)pageSize)
         });
        
    }
}
