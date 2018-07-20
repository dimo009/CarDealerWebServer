
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

        public IEnumerable<SupplierModel> All(bool isImporter)
        {
            var result = db.Suppliers
                .Where(s => s.IsImporter == isImporter)
                .Select(s => new SupplierModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    TotalParts = s.Parts.Count

                }).ToList();

            return result;

        }
    }
}
