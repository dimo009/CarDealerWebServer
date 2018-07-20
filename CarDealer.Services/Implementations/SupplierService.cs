
namespace CarDealer.Services.Implementations
{
    using CarDealer.Services.Models.Suppliers;
    using Data;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class SupplierService:ISupplierService
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierModel> All()
        {
            return this.db.Suppliers.OrderBy(s => s.Name).Select(s => new SupplierModel
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
        }

        public IEnumerable<SupplierListingModel> AllListings(bool isImporter)
        {
            var result = db.Suppliers
                .Where(s => s.IsImporter == isImporter)
                .Select(s => new SupplierListingModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    TotalParts = s.Parts.Count

                }).ToList();

            return result;

        }
    }
}
