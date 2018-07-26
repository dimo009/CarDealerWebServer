using CarDealer.Services.Models;
using CarDealer.Services.Models.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services
{
    public interface IPartService
    {
        IEnumerable<PartListingModel> AllListings(int page = 1, int pageSize = 10);

        IEnumerable<PartBasicModel> All();

        PartDetailsModel ById(int id);

        int TotalPages();

        void Create(string name, decimal price, int quantity, int supplierId);

        void Delete(int id);

        void Edit(int id, decimal price, int quantity);
    }
}
