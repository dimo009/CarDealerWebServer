

namespace CarDealer.Services.Implementations
{
    using CarDealer.Services.Cars.Models;
    using CarDealer.Services.Models.Cars;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICarService
    {
        IEnumerable<CarModel> ByMake(string make);

        IEnumerable<CarPartsModel> WithParts();
    }
}
