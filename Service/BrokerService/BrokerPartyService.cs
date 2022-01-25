using gaadi_ghoda_server.IRepository.IBrokerRepository;
using gaadi_ghoda_server.IService.IBrokerService;
using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.Service.BrokerService
{
    public class BrokerPartyService : IBrokerPartyService
    {
        private readonly IBrokerPartyRepository _brokerPartyRepository;

        public BrokerPartyService(IBrokerPartyRepository brokerPartyRepository)
        {
            _brokerPartyRepository = brokerPartyRepository;
        }

        public async Task<Party> Get(Guid id, string accountId)
        {
            return await _brokerPartyRepository.Get(id, accountId);
        }

        public async Task<List<Party>> Gets(string accountId)
        {
            return await _brokerPartyRepository.Gets(accountId);
        }

        public async Task<Party> Save(Party party, string accountId)
        {
            return await _brokerPartyRepository.Save(party, accountId);
        }

        public async Task<Party> Update(Party party, string accountId)
        {
            return await _brokerPartyRepository.Update(party, accountId);
        }

        public async Task<int> Delete(Guid id, string accountId)
        {
            return await _brokerPartyRepository.Delete(id, accountId);
        }
    }
}
