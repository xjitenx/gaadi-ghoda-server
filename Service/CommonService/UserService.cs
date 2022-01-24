using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using gaadi_ghoda_server.Models;
using gaadi_ghoda_server.IService.ICommonService;
using gaadi_ghoda_server.IRepository.ICommonRepository;
using Dapper;

namespace gaadi_ghoda_server.Service.CommonServie
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Get(Guid id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<List<User>> Gets()
        {
            return await _userRepository.Gets();
        }

        public async Task<User> Save(User user)
        {
            return await _userRepository.Save(user);
        }

        public async Task<User> Update(User user)
        {
            return await _userRepository.Update(user);
        }

        public async Task<int> Delete(Guid id)
        {
            return await _userRepository.Delete(id);
        }
    }
}
