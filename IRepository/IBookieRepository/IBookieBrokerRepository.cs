using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IRepository.IBookieRepository
{
    public interface IBookieBrokerRepository
    {
        Task<Broker> Get(Guid orgId, Guid bookieId, Guid brokerId);
        Task<List<Broker>> Gets(Guid orgId, Guid bookieId);
        Task<Broker> Save(Guid orgId, Guid bookieId, Broker broker);
        Task<Broker> Update(Guid orgId, Guid bookieId, Broker broker);
        Task<int> Delete(Guid orgId, Guid bookieId, Guid brokerId);
    }
}
