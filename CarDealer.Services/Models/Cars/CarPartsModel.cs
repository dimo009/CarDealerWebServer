

namespace CarDealer.Services.Models.Cars
{
    using CarDealer.Services.Cars.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CarPartsModel:CarModel
    {
        public IEnumerable<PartModel> Parts { get; set; }
    }
}
