

namespace CarDealer.Web.Controllers
{
    using CarDealer.Services.Implementations;
    using CarDealer.Web.Models.Cars;
    using Microsoft.AspNetCore.Mvc;

    [Route("cars")]
    public class CarsController:Controller
    {
        public readonly ICarService cars;

        public CarsController(ICarService cars)
        {
            this.cars = cars;
        }

        [Route(nameof(Create))]
        public IActionResult Create() => View();

        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(CarFormModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return View(carModel);
            }
            this.cars.Create(carModel.Make, carModel.Model, carModel.Distance);

            return RedirectToAction(nameof(Parts));

        }

        [Route("{make}", Order = 2)]
        public IActionResult ByMake(string make)
        {
            var cars = this.cars.ByMake(make);

            return View(new CarsByMakeModel
            {
                Make = make,
                Cars = cars
            });
        }


        [Route("parts", Order = 1)]
        public IActionResult Parts()
        {
            return View(this.cars.WithParts());
        }
    }
}
