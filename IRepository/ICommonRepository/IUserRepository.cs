using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IRepository.ICommonRepository
{
    public interface IUserRepository
    {
        Task<User> Get(Guid orgId, Guid userId);
        Task<List<User>> Gets(Guid orgId);
        Task<User> Save(Guid orgId, User user);
        Task<User> Update(Guid orgId, User user);
        Task<int> Delete(Guid orgId, Guid userId);
    }
}
