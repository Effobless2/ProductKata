using ProductKata.Domain.Models;
using ProductKata.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductKata.DB
{
    public class PriceRepository :  IPriceRepository
    {
        private List<Price> database = new();
        public Task<int> Add(Price item)
        {
            database.Add(item);
            return Task.FromResult(database.Count);
        }

        public Task<Price> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Price>> Get()
        {
            return Task.FromResult(database.AsEnumerable());
        }

        public Task<Price> GetByProductId(int productId)
        {
            List<Price> prices = database.Where(x => x.ProductId == productId).ToList();
            return Task.FromResult(prices.Find(x => x.UpdateDate == prices.Max(y => y.UpdateDate)));
        }

        public Task<Price> Update(Price item)
        {
            throw new NotImplementedException();
        }
    }
}
