using gaadi_ghoda_server.IRepository.ICommonRepository;
using gaadi_ghoda_server.IService.ICommonService;
using gaadi_ghoda_server.Models;

namespace gaadi_ghoda_server.Service.CommonServie
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<User> isValidUserCredentials(AuthRequest authRequest)
        {
            return await _authRepository.authenticateUserIdPassword(authRequest.LoginId, authRequest.Password);
        }

        public void logout()
        {
            throw new NotImplementedException();
        }

        public bool isValidCredentials(string loginId, string password)
        {
            if (string.IsNullOrWhiteSpace(loginId))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            return true;
        }
    }
}
