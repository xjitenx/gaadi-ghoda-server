using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IService.IBookieService
{
    public interface IBookieBrokerService
    {
        Task<Broker> Get(string bookieId, string brokerId);
        Task<List<Broker>> Gets(string bookieId);
        Task<Broker> Save(Broker broker, string bookieId);
        Task<Broker> Update(Broker broker, string bookieId);
        Task<int> Delete(Guid id, string bookieId);
    }
}
