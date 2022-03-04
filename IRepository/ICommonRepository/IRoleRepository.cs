using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.IRepository.ICommonRepository
{
    public interface IRoleRepository
    {
        Task<Role> Get(Guid orgId, Guid roleId);
        Task<List<Role>> Gets(Guid orgId);
        Task<Role> Save(Guid orgId, Role role);
        Task<Role> Update(Guid orgId, Role role);
        Task<int> Delete(Guid orgId, Guid roleId);
    }
}
