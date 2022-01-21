using gaadi_ghoda_server.IRepository;
using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.Repository
{
    public class BrokerRepository : IBrokerRepository
    {
        public Task<Broker> Save(Broker broker)
        {
            throw new NotImplementedException();
        }

        public Task<Broker> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Broker>> Gets()
        {
            throw new NotImplementedException();
        }

        public Task<Broker> Update(Broker broker)
        {
            throw new NotImplementedException();
        }

        public Task<Broker> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
