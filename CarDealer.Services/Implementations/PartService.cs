

namespace CarDealer.Services.Implementations
{
    using CarDealer.Data;
    using CarDealer.Data.Models;
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

        public void Create(string name, decimal price, int quantity, int supplierId)
        {
            var part = new Part
            {
                Name = name,
                Price = price,
                Quantity = quantity > 0 ? quantity: 1,
                SupplierId = supplierId
            };

            if (this.db.Parts.Any(p=>p.Name ==name) && this.db.Parts.FirstOrDefault(p => p.Name == name).SupplierId==supplierId)
            {
                this.db.Parts.FirstOrDefault(p => p.Name == name).Quantity += quantity;
                this.db.Parts.FirstOrDefault(p => p.Name == name).Price = price;
            }
            else
            {
                this.db.Parts.Add(part);
                
            }
            this.db.SaveChanges();
        }

        public int TotalPages()
        {
            return this.db.Parts.Count();
        }
    }
}
