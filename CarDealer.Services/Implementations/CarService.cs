

namespace CarDealer.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Data;
    using Cars.Models;
    using CarDealer.Services.Models.Cars;
    using CarDealer.Services.Models;
    using CarDealer.Data.Models;

    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;

        public CarService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CarModel> ByMake(string make)
        {
           var result = this.db
                .Cars
                .Where(c => c.Make.ToLower() == make.ToLower())
                .OrderBy(c => c.Model)
                .ThenBy(c => c.Distance)
                .Select(c => new CarModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    Distance = c.Distance
                })
              .ToList();

            return result;
        }

        public void Create(string make, string model, long distance,IEnumerable<int> parts)
        {
            var existingPartIds = this.db.Parts.Where(p => parts.Contains(p.Id)).Select(p=>p.Id).ToList();

            var car = new Car
            {

                Make = make,
                Model = model,
                Distance = distance
                                
            };

            foreach (var partId in existingPartIds)
            {
                car.Parts.Add(new PartCar { PartId = partId });
            }
            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }

        public IEnumerable<CarPartsModel> WithParts()
        {
            var result = this.db
                .Cars
                .Select(c => new CarPartsModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    Distance = c.Distance,
                    Parts = c.Parts.Select(p => new PartModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                }).ToList();

            return result;
        }
    }
}
