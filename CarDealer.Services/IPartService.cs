using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services
{
    public interface IPartService
    {
        IEnumerable<PartListingModel> All(int page = 1, int pageSize = 10);

        int TotalPages();

        void Create(string name, decimal price, int quantity, int supplierId);
        void Delete(int id);
    }
}
