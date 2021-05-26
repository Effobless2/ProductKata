using ProductKata.Domain.Models;
using ProductKata.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductKata.UnitTests.Repositories
{
    public class MockProductCatalogRepository : IProductCatalogRepository
    {
        private List<ProductCatalog> database = new();
        public Task<int> Add(ProductCatalog item)
        {
            database.Add(item);
            return Task.FromResult(database.Count);
        }

        public Task<ProductCatalog> Get(int id)
        {
            return Task.FromResult(database.Find(x => x.Id == id));
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
