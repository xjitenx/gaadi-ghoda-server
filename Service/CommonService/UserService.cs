using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.IService.ICommonService;
using gaadi_ghoda_server.IRepository.ICommonRepository;
using Dapper;

namespace gaadi_ghoda_server.Service.CommonService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Get(Guid orgId, Guid userId)
        {
            return await _userRepository.Get(orgId, userId);
        }

        public async Task<List<User>> Gets(Guid orgId)
        {
            return await _userRepository.Gets(orgId);
        }

        public async Task<User> Save(Guid orgId, User user)
        {
            return await _userRepository.Save(orgId, user);
        }

        public async Task<User> Update(Guid orgId, User user)
        {
            return await _userRepository.Update(orgId, user);
        }

        public async Task<int> Delete(Guid orgId, Guid userId)
        {
            return await _userRepository.Delete(orgId, userId);
        }
    }
}
