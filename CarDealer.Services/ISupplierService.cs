

namespace CarDealer.Services
{
    using Models.Suppliers;
   
    using System.Collections.Generic;
    

    public interface ISupplierService
    {
        IEnumerable<SupplierModel> All(bool isImporter);
    }
}
