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

        public async Task<Party> Get(Guid id)
        {
            return await _brokerPartyRepository.Get(id);
        }

        public async Task<List<Party>> Gets()
        {
            return await _brokerPartyRepository.Gets();
        }

        public async Task<Party> Save(Party party)
        {
            return await _brokerPartyRepository.Save(party);
        }

        public async Task<Party> Update(Party party)
        {
            return await _brokerPartyRepository.Update(party);
        }

        public async Task<Party> Delete(Guid id)
        {
            return await _brokerPartyRepository.Delete(id);
        }
    }
}
