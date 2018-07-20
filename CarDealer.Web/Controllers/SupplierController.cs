

namespace CarDealer.Web.Controllers
{
    using Services;
    using Models.Suppliers;
    using Microsoft.AspNetCore.Mvc;
    
    [Route("suppliers")]
    public class SupplierController:Controller
    {
        private readonly ISupplierService suppliers;
        private const string SuppliersView = "SuppliersView";

        public SupplierController(ISupplierService suppliers)
        {
            this.suppliers = suppliers;
        }

        [Route("locals")]
        public IActionResult Local()
        {
            return View(SuppliersView, this.GetSupplierModel(false));
        }
        [Route("importers")]
        public IActionResult Importers()
        {
            return View(SuppliersView, this.GetSupplierModel(true));
        }

        private SuppliersModel GetSupplierModel(bool importers)
        {
            var type = importers ? "Importer" : "Local";
            var suppliers = this.suppliers.AllListings(importers);
            return new SuppliersModel
            {

                Type = type,
                Suppliers = suppliers
            };
               
        }

    }
}
