using gaadi_ghoda_server.IRepository;
using gaadi_ghoda_server.IService;
using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<User> login(AuthRequest authRequest)
        {
            return await _authRepository.login(authRequest.LoginId, authRequest.Password);
        }

        public void logout()
        {
            throw new NotImplementedException();
        }
    }
}
