using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IRepository.IBookieRepository
{
    public interface IBookiePartyRepository
    {
        Task<Party> Get(Guid id, string accountId);
        Task<List<Party>> Gets(string accountId);
        Task<Party> Save(Party party, string accountId);
        Task<Party> Update(Party party, string accountId);
        Task<int> Delete(Guid id, string accountId);
    }
}
