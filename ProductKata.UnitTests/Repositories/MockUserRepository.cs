using ProductKata.Domain.Models;
using ProductKata.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductKata.UnitTests.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> database = new();
        public Task<int> Add(User item)
        {
            database.Add(item);
            item.Id = database.Count;
            return Task.FromResult(item.Id);
        }

        public Task<User> Get(int id)
        {
            return Task.FromResult(database.Find(x => x.Id == id));
        }

        public Task<IEnumerable<User>> Get()
        {
            return Task.FromResult(database.AsEnumerable());
        }

        public Task<User> GetByLogin(string login)
        {
            return Task.FromResult(database.Find(x => x.Login == login));
        }

        public Task<User> Update(User item)
        {
            database[item.Id] = item;
            return Task.FromResult(item);
        }
    }
}
