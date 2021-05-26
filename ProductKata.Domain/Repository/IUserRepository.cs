using ProductKata.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductKata.Domain.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByLogin(string login);
    }
}
