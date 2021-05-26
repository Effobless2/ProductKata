using ProductKata.Domain.Models;
using ProductKata.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductKata.UnitTests.Repositories
{
    public class MockSellHistoryRepository : ISellHistoryRepository
    {
        private static List<SellHistory> database = new();
        public Task<int> Add(SellHistory item)
        {
            database.Add(item);
            return Task.FromResult(database.Count);
        }

        public Task<SellHistory> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SellHistory>> Get()
        {
            return Task.FromResult(database.AsEnumerable());
        }

        public Task<IEnumerable<SellHistory>> GetByUserId(int userId)
        {
            return Task.FromResult(database.Where(x => x.UserId == userId));
        }

        public Task<SellHistory> Update(SellHistory item)
        {
            throw new NotImplementedException();
        }
    }
}
