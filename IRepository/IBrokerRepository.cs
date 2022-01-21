using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IRepository
{
    public interface IBrokerRepository
    {
        Task<Broker> Save(Broker broker);
        Task<Broker> Get(Guid id);
        Task<List<Broker>> Gets();
        Task<Broker> Update(Broker broker);
        Task<Broker> Delete(Guid id);
    }
}
