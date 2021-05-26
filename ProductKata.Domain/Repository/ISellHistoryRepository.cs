using ProductKata.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductKata.Domain.Repository
{
    public interface ISellHistoryRepository : IRepository<SellHistory>
    {
        Task<IEnumerable<SellHistory>> GetByUserId(int userId);
    }
}
