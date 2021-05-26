using ProductKata.Domain.Models;
using ProductKata.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductKata.DB
{
    public class SellHistoryRepository : ISellHistoryRepository
    {
        private List<SellHistory> database = new();
        public Task<int> Add(SellHistory item)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Task<SellHistory> Update(SellHistory item)
        {
            throw new NotImplementedException();
        }
    }
}
