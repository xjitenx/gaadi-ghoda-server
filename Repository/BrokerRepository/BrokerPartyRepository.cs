using gaadi_ghoda_server.IRepository.IBrokerRepository;
using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.Repository.BrokerRepository
{
    public class BrokerPartyRepository : IBrokerPartyRepository
    {
        public Task<Party> Get(Guid id, string accountId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Party>> Gets(string accountId)
        {
            throw new NotImplementedException();
        }

        public Task<Party> Save(Party party, string accountId)
        {
            throw new NotImplementedException();
        }

        public Task<Party> Update(Party party, string accountId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid id, string accountId)
        {
            throw new NotImplementedException();
        }
    }
}
