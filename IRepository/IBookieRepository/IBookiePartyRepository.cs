using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IRepository.IBookieRepository
{
    public interface IBookiePartyRepository
    {
        Task<Party> Get(Guid id);
        Task<List<Party>> Gets();
        Task<Party> Save(Party party);
        Task<Party> Update(Party party);
        Task<int> Delete(Guid id);
    }
}
