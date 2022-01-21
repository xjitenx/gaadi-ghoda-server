using gaadi_ghoda_server.IRepository;
using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<User> Save(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> Gets()
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
