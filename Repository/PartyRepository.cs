using gaadi_ghoda_server.IRepository;
using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.Repository
{
    public class PartyRepository : IPartyRepository
    {
        public Task<Party> Save(Party party)
        {
            throw new NotImplementedException();
        }

        public Task<Party> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Party>> Gets()
        {
            throw new NotImplementedException();
        }

        public Task<Party> Update(Party party)
        {
            throw new NotImplementedException();
        }

        public Task<Party> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
