
namespace CarDealer.Web.Models.Customers
{

    using CarDealer.Services.Models;
    using System.Collections.Generic;


    public class AllCustomersModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }

        public OrderingType OrderingType { get; set; }
    }
}
