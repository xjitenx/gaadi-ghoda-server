using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IRepository.IBookieRepository
{
    public interface IBookieBrokerRepository
    {
        Task<Broker> Save(Broker broker);
        Task<Broker> Get(Guid id);
        Task<List<Broker>> Gets();
        Task<Broker> Update(Broker broker);
        Task<int> Delete(Guid id);
    }
}
