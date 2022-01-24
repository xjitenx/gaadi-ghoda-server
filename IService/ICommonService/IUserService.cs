using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IService.ICommonService
{
    public interface IUserService
    {
        Task<User> Save(User user);
        Task<User> Get(Guid id);
        Task<List<User>> Gets();
        Task<User> Update(User user);
        Task<int> Delete(Guid id);
    }
}
