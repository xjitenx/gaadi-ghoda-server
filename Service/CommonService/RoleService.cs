using gaadi_ghoda_server.IRepository.ICommonRepository;
using gaadi_ghoda_server.IService.ICommonService;
using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.Service.CommonService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> Get(Guid orgId, Guid roleId)
        {
            return await _roleRepository.Get(orgId, roleId);
        }

        public async Task<List<Role>> Gets(Guid orgId)
        {
            return await _roleRepository.Gets(orgId);
        }

        public async Task<Role> Save(Guid orgId, Role role)
        {
            return await _roleRepository.Save(orgId, role);
        }

        public async Task<Role> Update(Guid orgId, Role role)
        {
            return await _roleRepository.Update(orgId, role);
        }

        public async Task<int> Delete(Guid orgId, Guid roleId)
        {
            return await _roleRepository.Delete(orgId, roleId);
        }
    }
}
