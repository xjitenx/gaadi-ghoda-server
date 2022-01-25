using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IService.IBookieService
{
    public interface IBookieBrokerService
    {
        Task<Broker> Get(Guid id, string bookieId);
        Task<List<Broker>> Gets(string bookieId);
        Task<Broker> Save(Broker broker, string bookieId);
        Task<Broker> Update(Broker broker, string bookieId);
        Task<int> Delete(Guid id, string bookieId);
    }
}
