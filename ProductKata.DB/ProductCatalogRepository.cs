using ProductKata.Domain.Models;
using ProductKata.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductKata.DB
{
    public class ProductCatalogRepository : IProductCatalogRepository
    {
        private List<ProductCatalog> database = new();
        public Task<int> Add(ProductCatalog item)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCatalog> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductCatalog>> Get()
        {
            return Task.FromResult(database.AsEnumerable());
        }

        public Task<ProductCatalog> Update(ProductCatalog item)
        {
            throw new NotImplementedException();
        }
    }
}
