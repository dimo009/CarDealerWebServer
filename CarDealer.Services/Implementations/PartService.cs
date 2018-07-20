

namespace CarDealer.Services.Implementations
{
    using CarDealer.Data;
    using CarDealer.Services.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class PartService:IPartService
    {
       

        private readonly CarDealerDbContext db;

        public PartService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<PartListingModel> All(int page = 1, int pageSize = 10) => this.db
            .Parts
            .OrderByDescending(p=>p.Id)
            .Skip((page-1)*pageSize)
            .Take(25)
            .Select(p => new PartListingModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Qualtity = p.Quantity,
                SupplierName = p.Supplier.Name
            }).ToList();

        public int TotalPages()
        {
            return this.db.Parts.Count();
        }
    }
}
