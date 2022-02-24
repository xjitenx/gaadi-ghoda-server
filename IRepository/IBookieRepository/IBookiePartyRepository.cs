using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IRepository.IBookieRepository
{
    public interface IBookiePartyRepository
    {
        Task<Party> Get(Guid orgId, Guid bookieId, Guid partyId);
        Task<List<Party>> Gets(Guid orgId, Guid bookieId);
        Task<Party> Save(Guid orgId, Guid bookieId, Party party);
        Task<Party> Update(Guid orgId, Guid bookieId, Party party);
        Task<int> Delete(Guid orgId, Guid bookieId, Guid partyId);
    }
}
